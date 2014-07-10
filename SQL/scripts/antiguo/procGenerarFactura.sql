create procedure THE_GRID.GenerarFactura 
				@top int,
				@ID_Vendedor numeric(18,0),
				@fecha date, 
				@formaPago nvarchar(255), 
				@tarjeta numeric(20,0)
as
begin tran

declare publicaciones cursor for
select top (@top) p.ID_Publicacion,
v.Precio_Por_Publicar, v.Porcentaje_Venta * 100 'Porcentaje_Venta',
v.ID_Tipo, isnull((select contador from THE_GRID.Contador_Visibilidad_x_Vendedor cv
where cv.ID_Tipo = v.ID_Tipo and cv.ID_Vendedor = (@ID_Vendedor)),0) Contador
from THE_GRID.Publicacion p inner join THE_GRID.Estado_Publicacion ep on 
p.ID_Estado = ep.ID_Estado and ep.Nombre = 'Publicada' 
and p.Facturada = 0 and p.ID_Vendedor = (@ID_Vendedor) 
inner join THE_GRID.Visibilidad v on p.ID_Visibilidad = v.ID_Visibilidad 
inner join THE_GRID.Compra c on p.ID_Publicacion = c.ID_Publicacion
group by p.ID_Publicacion, v.Precio_Por_Publicar,v.Porcentaje_Venta, v.ID_Tipo, p.Fecha_Inicio
order by p.Fecha_Inicio

open publicaciones
declare @ID_Publicacion numeric(18,0);
declare @precioPublicar numeric(18,2);
declare @porcentajeVenta numeric(18,2);
declare @ID_Tipo numeric(18,0);
declare @contador numeric(2,0);
declare @nroFactura numeric(18,0);

set @nroFactura = (select MAX(ID_Factura) + 1 from THE_GRID.Factura)
insert into THE_GRID.Factura values(@nroFactura,@ID_Vendedor,@fecha,@formaPago,@tarjeta,0)

fetch next from publicaciones into @ID_Publicacion,@precioPublicar,@porcentajeVenta,@ID_Tipo,@contador

while @@FETCH_STATUS = 0 
begin
	if @contador = 0 insert into THE_GRID.Contador_Visibilidad_x_Vendedor values(@ID_Tipo,@ID_Vendedor,0)
	
	update THE_GRID.Contador_Visibilidad_x_Vendedor set Contador = @contador+1
	where ID_Tipo = @ID_Tipo and ID_Vendedor = @ID_Vendedor
	
	if @contador = 10 
	begin 
		insert into THE_GRID.RenglonFactura
		select @nroFactura, @ID_Publicacion, 0, c.Item_Cantidad 
		from THE_GRID.Compra c where ID_Publicacion = @ID_Publicacion
	
		insert into THE_GRID.RenglonFactura values(@nroFactura,@ID_Publicacion,0,1)
		
		update THE_GRID.Contador_Visibilidad_x_Vendedor set Contador = 1
		where ID_Tipo = @ID_Tipo and ID_Vendedor = @ID_Vendedor
	end
	else
	begin
		insert into THE_GRID.RenglonFactura
		select @nroFactura, @ID_Publicacion, c.Item_Monto*c.Item_Cantidad*@porcentajeVenta, c.Item_Cantidad 
		from THE_GRID.Compra c where ID_Publicacion = @ID_Publicacion
	
		insert into THE_GRID.RenglonFactura values(@nroFactura,@ID_Publicacion,@precioPublicar,1)
	end
	
	fetch next from publicaciones into @ID_Publicacion,@precioPublicar,@porcentajeVenta,@ID_Tipo,@contador
end

close publicaciones
deallocate publicaciones

update THE_GRID.Factura 
set Total = (select SUM(Item_Monto) from THE_GRID.RenglonFactura r where r.ID_Factura = @nroFactura)              
where ID_Factura = @nroFactura
commit
go