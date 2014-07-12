use GD1C2014
GO

if not exists(select * from sys.schemas where name = 'THE_GRID')
execute('CREATE SCHEMA [THE_GRID] AUTHORIZATION [gd]')

else print('No te creo nada')
GO

create table THE_GRID.Tipo_Usuario(
    ID_Tipo int identity(1,1) primary key,
    Nombre nvarchar(255) not null,
    Descripcion nvarchar(255)
)
go

create table THE_GRID.Usuario(
	ID_User numeric(18,0) identity(1000,1) Primary key,
	Pass nvarchar(255),
	Inhabilitado bit,
	Eliminado bit,
	ID_Tipo int References THE_GRID.Tipo_Usuario(ID_Tipo),
	Intentos int,
	Primer_Ingreso bit,
	Datos_Correctos bit
)
go

create table THE_GRID.Cliente(
	ID_User numeric(18,0) references THE_GRID.Usuario(ID_User),
    Nombre nvarchar(255), 
    Apellido nvarchar(255),
    Tipo_Documento nvarchar(255), 
    Documento numeric(18,0),
    Mail nvarchar(255),
    Telefono numeric(18,0),
    Fecha_Nacimiento datetime, 
    Nro_Tarjeta nvarchar(40),
    Calle nvarchar(255), 
	Nro_Calle numeric(18,0), 
	Nro_Piso numeric(18,0), 
	Departamento nvarchar(50), 
	Localidad nvarchar(255),
	Cod_Postal nvarchar(50),
	Ciudad nvarchar(255)
    Primary Key(ID_User)
)
go

create table THE_GRID.Empresa(
	ID_User numeric(18,0) references THE_GRID.Usuario(ID_User),
    Razon_Social nvarchar(255),  
    CUIT nvarchar(50),
    Mail nvarchar(255),
    Telefono numeric(18,0),
    Fecha_Creacion datetime,
    Nombre_Contacto nvarchar(255),
    Calle nvarchar(255), 
	Nro_Calle numeric(18,0), 
	Nro_Piso numeric(18,0), 
	Departamento nvarchar(50), 
	Localidad varchar(20),
	Cod_Postal nvarchar(50),
	Ciudad nvarchar(20)
    Primary Key(ID_User)
)
go

create table THE_GRID.Administrador(
	ID_User numeric(18,0) references THE_GRID.Usuario(ID_User),
    Nombre nvarchar(255),
    Primary Key(ID_User)
)
go

create table THE_GRID.Anomalia(
	ID_User numeric(18,0) references THE_GRID.Usuario(ID_User),
    Detalle nvarchar(255),
    Fecha date
)
go


create table THE_GRID.Rol(
	ID_Rol numeric(18,0) identity(1,1) primary key,
	Nombre varchar(20) unique,
	Inhabilitado bit
)
go

create table THE_GRID.Rubro(
	ID_Rubro numeric(18,0) identity(100,1) primary key,
	Nombre varchar(256) unique,
)
go

create table THE_GRID.Tipo_Publicacion(
	ID_Tipo numeric(18,0) identity(100,1) primary key,
	Nombre varchar(256) unique,
)
go

create table THE_GRID.Estado_Publicacion(
	ID_Estado numeric(18,0) identity(100,1) primary key,
	Nombre varchar(256) unique,
)
go


create table THE_GRID.Tipo_Visibilidad(
	ID_Tipo numeric(18,0) identity(1,1) primary key,
	Nombre varchar(256)
)
go

create table THE_GRID.Visibilidad(
	ID_Visibilidad numeric(18,0) identity(10002,1) primary key,
	Nombre varchar(256),
	Precio_Por_Publicar numeric(18,2),
	Porcentaje_Venta numeric(18,2),
	Duracion numeric(3,0),
	Inhabilitado bit,
	ID_Tipo numeric(18,0) references THE_GRID.Tipo_Visibilidad(ID_Tipo)
)
go

create table THE_GRID.Contador_Visibilidad_x_Vendedor(
	ID_Tipo numeric(18,0) references THE_GRID.Tipo_Visibilidad(ID_Tipo),
	ID_Vendedor numeric(18,0) references THE_GRID.Usuario(ID_User),
	Contador numeric(2,0)
	primary key(ID_Tipo,ID_Vendedor)
)
go

create table THE_GRID.Roles_x_Usuario(
	ID_User numeric(18,0) references THE_GRID.Usuario(ID_User),
	ID_Rol numeric(18,0) references THE_GRID.Rol(ID_Rol),
	Inhabilitado bit,
	Primary Key(ID_User,ID_Rol)
)
go

create table THE_GRID.Funcionalidad(
	ID_Funcionalidad numeric(18,0) identity(1,1) primary key,
	Nombre nvarchar(255),
	Descripcion nvarchar(255)
)
go

create table THE_GRID.Funcionalidades_x_Rol(
	ID_Rol numeric(18,0) references THE_GRID.Rol(ID_Rol),
	ID_Funcionalidad numeric(18,0) references THE_GRID.Funcionalidad(ID_Funcionalidad),
	Primary Key(ID_Rol,ID_Funcionalidad)
)
go

create table THE_GRID.Publicacion(
    ID_Publicacion numeric(18,0) /*identity(1000000,1)*/ Primary Key,
	Descripcion nvarchar(255),
	Stock numeric(18,0),
	Fecha_Inicio datetime,
	Fecha_Vencimiento datetime,
	Precio numeric(18,2),
	ID_Visibilidad numeric(18,0) references THE_GRID.Visibilidad(ID_Visibilidad),
	ID_Vendedor numeric(18,0) references THE_GRID.Usuario(ID_User),
	ID_Estado numeric(18,0) references THE_GRID.Estado_Publicacion(ID_Estado),
	ID_Tipo numeric(18,0) references THE_GRID.Tipo_Publicacion(ID_Tipo),
	Permitir_Preguntas bit,
	Facturada bit			
)
go

create table THE_GRID.Rubros_x_Publicacion(
	ID_Publicacion numeric(18,0) references THE_GRID.Publicacion(ID_Publicacion),
	ID_Rubro numeric(18,0) references THE_GRID.Rubro(ID_Rubro)
	Primary key(ID_Publicacion,ID_Rubro)
)
go

create table THE_GRID.Oferta(
	ID_Oferta numeric(18,0) identity(1000000,1) Primary Key,
	ID_Ofertante numeric(18,0) references THE_GRID.Usuario(ID_User),
	ID_Publicacion numeric(18,0) references THE_GRID.Publicacion(ID_Publicacion),
	Concretada bit,
	Fecha_Oferta date,
	Monto_Oferta numeric(18,0),
)
go

create table THE_GRID.Compra(
	ID_Operacion numeric(18,0) identity(1000000,1) Primary Key,
	ID_Publicacion numeric(18,0) references THE_GRID.Publicacion(ID_Publicacion),
	ID_Comprador numeric(18,0) references THE_GRID.Usuario(ID_User),
	Item_Cantidad numeric(18,0),
	Item_Monto numeric(18,2),
	Fecha date,
	Pagada bit,
	Calif_Estrellas numeric(18,0),
	Calif_Detalle nvarchar(255),
)
go

create table THE_GRID.Factura(
	ID_Factura numeric(18,0) primary key,
	ID_Vendedor numeric(18,0) references THE_GRID.Usuario(ID_User),
	Fecha date,
	Forma_Pago nvarchar(255),
	Nro_Tarjeta numeric(20,0),
	Total numeric(18,2)
)
go

create table THE_GRID.RenglonFactura(
	ID_Renglon numeric (18,0) identity (1,1) primary key,
	ID_Factura numeric(18,0) references THE_GRID.Factura(ID_Factura),
	ID_Publicacion numeric(18,0) references THE_GRID.Publicacion(ID_Publicacion),
	Item_Monto numeric(18,2),
	Item_Cantidad numeric(18,0)
)
go

create table THE_GRID.Pregunta(
	ID_Pregunta numeric(18,0) identity(1000000,1) Primary Key,
	ID_Publicacion numeric(18,0) references THE_GRID.Publicacion(ID_Publicacion),
	Pregunta nvarchar(255),
	Fecha_Pregunta date,
	Respuesta nvarchar(255),
	Fecha_Respuesta date,
	ID_Comprador numeric(18,0) references THE_GRID.Usuario(ID_User),
	ID_Vendedor numeric(18,0) references THE_GRID.Usuario(ID_User)
)

GO

insert into THE_GRID.Rol(Nombre,Inhabilitado) values('Administrador',0)
insert into THE_GRID.Rol(Nombre,Inhabilitado) values('Comprador',0)
insert into THE_GRID.Rol(Nombre,Inhabilitado) values('Vendedor',0)

insert into THE_GRID.Tipo_Usuario(Nombre,Descripcion) values('Administrador','Administrador General')
insert into THE_GRID.Tipo_Usuario(Nombre,Descripcion) values('Cliente','Usuario individual, comprador y vendedor')
insert into THE_GRID.Tipo_Usuario(Nombre,Descripcion) values('Empresa','Empresa, solo vendedor')

--Funcionalidades -----------------------------------------------------------------------
insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('ABM Usuario','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('ABM Cliente','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('ABM Empresa','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('ABM Rol','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('ABM Rubro','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('ABM Visibilidad','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Listado Estadistico','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Calificar Vendedor','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Comprar - Ofertar','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Editar Publicacion','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Facturar Publicaciones','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Generar Publicacion','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Gestion De Preguntas','Soy una descripcion')

insert into THE_GRID.Funcionalidad(Nombre,Descripcion)
values('Historial del Cliente','Soy una descripcion')

--Funcionalidades por Rol -------------------------------

insert into THE_GRID.Funcionalidades_x_Rol
select 1,ID_Funcionalidad from THE_GRID.Funcionalidad

------------------------------------------------------------------------------------

insert into THE_GRID.Funcionalidades_x_Rol 
values(2,8)

insert into THE_GRID.Funcionalidades_x_Rol 
values(2,9)

insert into THE_GRID.Funcionalidades_x_Rol 
values(2,13)

insert into THE_GRID.Funcionalidades_x_Rol 
values(2,14)

------------------------------------------------------------------------------------

insert into THE_GRID.Funcionalidades_x_Rol 
values(3,10)

insert into THE_GRID.Funcionalidades_x_Rol 
values(3,11)

insert into THE_GRID.Funcionalidades_x_Rol 
values(3,12)

insert into THE_GRID.Funcionalidades_x_Rol 
values(3,13)

insert into THE_GRID.Funcionalidades_x_Rol 
values(3,14)

GO

------------------------------------------------------------------------------------------------
--Funciones

create function THE_GRID.dameUserIDdni (@dni numeric(18,0)) returns numeric(18,0) as
begin
	return (select c.ID_User from THE_GRID.Cliente c where @dni = c.Documento )
end
GO

create function THE_GRID.dameUserIDcuit (@cuit nvarchar(50)) returns numeric(18,0) as
begin
	return (select e.ID_User from THE_GRID.Empresa e where @cuit = e.CUIT )
end
GO

-------------------------------------------------------------------------------------------------
--Vistas estadisticas

create view THE_GRID.Estad_Productos as
select U.ID_User Usuario,(SUM(P.Stock)) as Cantidad, V.Nombre Visibilidad, V.Precio_Por_Publicar Precio_Visibilidad, 
MONTH(P.Fecha_Inicio) as Mes,
(case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end) as Trimestre,
YEAR(P.Fecha_Inicio) as Anio
from THE_GRID.Usuario U, THE_GRID.Publicacion P, THE_GRID.Visibilidad V
where P.ID_Vendedor = U.ID_User and P.ID_Visibilidad = V.ID_Visibilidad
group by YEAR(P.Fecha_Inicio), (case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end), MONTH(P.Fecha_Inicio), V.Precio_Por_Publicar, V.Nombre, U.ID_User
go

create view THE_GRID.Estad_Facturacion as
select u.ID_User Usuario,(SUM(F.Total)) as Facturacion,
(case when MONTH(F.Fecha) between 1 and 3 then 1
when MONTH(F.Fecha) between 4 and 6 then 2
when MONTH(F.Fecha) between 7 and 9 then 3
when MONTH(F.Fecha) between 10 and 12 then 4 end) as Trimestre,
YEAR(F.Fecha) as Anio
from THE_GRID.Factura F, THE_GRID.Usuario u
where F.ID_Vendedor = u.ID_User
group by YEAR(F.Fecha), (case when MONTH(F.Fecha) between 1 and 3 then 1
when MONTH(F.Fecha) between 4 and 6 then 2
when MONTH(F.Fecha) between 7 and 9 then 3
when MONTH(F.Fecha) between 10 and 12 then 4 end), u.ID_User
go

create view THE_GRID.Estad_Calificaciones as
select P.ID_Vendedor Usuario, (SUM(C.Calif_Estrellas)/COUNT(*)) as Calificacion,
(case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end) as Trimestre,
YEAR(C.Fecha) as Anio
from THE_GRID.Compra C, THE_GRID.Publicacion P
where C.ID_Publicacion = P.ID_Publicacion
group by YEAR(C.Fecha), (case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end), P.ID_Vendedor
go

create view THE_GRID.Estad_Calificar as
select C.ID_Comprador Usuario, COUNT(*) as Cantidad,
(case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end) as Trimestre,
YEAR(C.Fecha) as Anio
from THE_GRID.Compra C
where C.Calif_Estrellas = 0
group by YEAR(C.Fecha), (case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end), C.ID_Comprador
go

----------------------------------------------------------------------------
--Procedimiento de loggeo

create procedure THE_GRID.login @user numeric(18,0), @pass nvarchar(255), @protocolo int out as
begin

declare cursorUsuario cursor for (select ID_User,Pass,Inhabilitado,Intentos from THE_GRID.Usuario where ID_User = @user)
declare @user_t numeric(18,0)
declare @pass_t nvarchar(255)
declare @inhabilitado bit
declare @intentos int
declare @rowcount int

set @protocolo = 0;

open cursorUsuario;
fetch next from cursorUsuario into @user_t, @pass_t, @Inhabilitado, @Intentos
set @rowcount = @@ROWCOUNT

close cursorUsuario
deallocate cursorUsuario

if @rowcount = 0
begin
	set @protocolo = 1
	print 'Usuario No encontrado'
	return
end

if @Inhabilitado = 1
begin
	set @protocolo = 2
	print 'Usuario Inhabilitado'
	return
end

if @pass <> @pass_t
begin
	if @intentos >= 3
	begin
		set @protocolo = 4
	    update THE_GRID.Usuario set Inhabilitado=1 where ID_User=@user --el resto por trigger  :3
		print 'Pass erroneo y usuario Inhabilitado'
		return
	end
	
	else
	
	begin
		set @intentos = @intentos + 1
		set @protocolo = 3
		update THE_GRID.Usuario set Intentos = @intentos where ID_User = @user
		print 'Pass erroneo'
		return
	end
end
set @intentos = 1

if (select COUNT(*) from THE_GRID.Roles_x_Usuario where ID_User = @user AND Inhabilitado = 0) = 0
begin 
	set @protocolo = 5
end

update THE_GRID.Usuario set Intentos = @intentos where ID_User = @user
return

end
go

create procedure THE_GRID.GenerarFactura 
				@top int,
				@ID_Vendedor numeric(18,0),
				@fecha date, 
				@formaPago nvarchar(255), 
				@tarjeta numeric(20,0)
as
begin

declare publicaciones cursor for
select top (@top) p.ID_Publicacion,
v.Precio_Por_Publicar, v.Porcentaje_Venta,
v.ID_Tipo
from THE_GRID.Publicacion p 
inner join THE_GRID.Visibilidad v on p.ID_Visibilidad = v.ID_Visibilidad 
inner join THE_GRID.Compra c on p.ID_Publicacion = c.ID_Publicacion
where p.Fecha_Vencimiento <= @fecha and p.Facturada = 0 and p.ID_Vendedor = @ID_Vendedor             
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

fetch next from publicaciones into @ID_Publicacion,@precioPublicar,@porcentajeVenta,@ID_Tipo

while @@FETCH_STATUS = 0 
begin
	if (select COUNT(*) from THE_GRID.Contador_Visibilidad_x_Vendedor 
		where ID_Tipo = @ID_Tipo and ID_Vendedor = @ID_Vendedor) = 0
		begin 
	insert into THE_GRID.Contador_Visibilidad_x_Vendedor values(@ID_Tipo,@ID_Vendedor,0)
	set @contador = 1 
	end
	else
	set @contador = (select Contador from THE_GRID.Contador_Visibilidad_x_Vendedor
	where ID_Tipo = @ID_Tipo and ID_Vendedor = @ID_Vendedor) + 1
	
	update THE_GRID.Contador_Visibilidad_x_Vendedor set Contador = @contador
	where ID_Tipo = @ID_Tipo and ID_Vendedor = @ID_Vendedor
	
	update THE_GRID.Publicacion set Facturada = 1 where ID_Publicacion = @ID_Publicacion
	
	if @contador >= 10 
	begin 
		insert into THE_GRID.RenglonFactura
		select @nroFactura, @ID_Publicacion, 0, c.Item_Cantidad 
		from THE_GRID.Compra c where ID_Publicacion = @ID_Publicacion
	
		insert into THE_GRID.RenglonFactura values(@nroFactura,@ID_Publicacion,0,1)
		
		update THE_GRID.Contador_Visibilidad_x_Vendedor set Contador = 0
		where ID_Tipo = @ID_Tipo and ID_Vendedor = @ID_Vendedor
	end
	else
	begin
		insert into THE_GRID.RenglonFactura
		select @nroFactura, @ID_Publicacion, c.Item_Monto*c.Item_Cantidad*@porcentajeVenta, c.Item_Cantidad 
		from THE_GRID.Compra c where ID_Publicacion = @ID_Publicacion
	
		insert into THE_GRID.RenglonFactura values(@nroFactura,@ID_Publicacion,@precioPublicar,1)
	end
	
	fetch next from publicaciones into @ID_Publicacion,@precioPublicar,@porcentajeVenta,@ID_Tipo
end

close publicaciones
deallocate publicaciones

update THE_GRID.Factura 
set Total = (select SUM(Item_Monto) from THE_GRID.RenglonFactura r where r.ID_Factura = @nroFactura)              
where ID_Factura = @nroFactura
end
go

--------------------------------------------------------------------------------------------
--Triggers
create trigger THE_GRID.usuarioEliminado on THE_GRID.Usuario for update
as
begin

if update(Eliminado) begin
	declare usuariosModificados cursor for (select ID_User, Eliminado from inserted)
	declare @usuario numeric(18,0)
	declare @eliminado bit
	open usuariosModificados
	fetch next from usuariosModificados into @usuario, @eliminado
	while (@@fetch_status = 0)
	begin
		if @eliminado = 1
		update THE_GRID.Publicacion set ID_Estado= 103 where ID_Vendedor = @usuario
		fetch next from usuariosModificados into @usuario, @eliminado
	end
	close usuariosModificados
	deallocate usuariosModificados
end
end
go

create trigger THE_GRID.inhabilitarUsuario on THE_GRID.Usuario for update 
as
begin

if update(Inhabilitado) begin
	declare usuariosModificados cursor for (select ID_User, Inhabilitado, Eliminado from inserted)
	declare @usuario numeric(18,0)
	declare @inhabilitado bit
	declare @eliminado bit
	open usuariosModificados
	fetch next from usuariosModificados into @usuario, @inhabilitado, @eliminado
	while (@@fetch_status = 0)
	begin
		if @inhabilitado = 1 and @eliminado = 0
		update THE_GRID.Publicacion set ID_Estado= 102 where ID_Vendedor = @usuario and ID_Estado = 100
	fetch next from usuariosModificados into @usuario, @inhabilitado, @eliminado
	end
	close usuariosModificados
	deallocate usuariosModificados
end
end

go

create trigger THE_GRID.inhabilitarRoles on THE_GRID.Rol for update as
begin

declare rolesModificados cursor for (select ID_Rol, Inhabilitado from inserted)
declare @ID_Rol numeric(18,0)
declare @Inhabilitado bit

open rolesModificados
fetch next from rolesModificados into @ID_Rol, @Inhabilitado 

while (@@fetch_status = 0)
begin

if @Inhabilitado = 1
update THE_GRID.Roles_X_Usuario set Inhabilitado = 1 where ID_Rol = @ID_Rol

fetch next from rolesModificados into @ID_Rol, @Inhabilitado
end

close rolesModificados
deallocate rolesModificados

end
go

------------------------------------------------------------------------------------------
--Migracion de usuarios, Clientes, Empresas

declare @dni int declare @apellido varchar(15) declare @nombre varchar(15) 
declare @nacimiento date declare @mail varchar(30) declare @calle varchar(64) 
declare @nro int declare @piso int declare @depto varchar(16) declare @postal int
declare @contador int
set @contador = 1000

declare cursorCliente cursor for 
SELECT DISTINCT Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal
  FROM [GD1C2014].[gd_esquema].[Maestra]
  where Publ_Cli_Dni is not null;

open cursorCliente
fetch next from cursorCliente
 into @dni, @apellido, @nombre, @nacimiento, @mail, @calle, @nro, @piso, @depto, @postal
	----------COMIENZO DEL WHILE
while(@@FETCH_STATUS = 0)
begin

insert into GD1C2014.THE_GRID.Usuario (Pass,Inhabilitado,Eliminado,ID_Tipo,Intentos, Primer_Ingreso, Datos_Correctos) 
values('37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f',0,0,2,1,1,0)
insert into GD1C2014.THE_GRID.Roles_x_Usuario values(@contador,2,0)
insert into GD1C2014.THE_GRID.Roles_x_Usuario values(@contador,3,0)
insert into GD1C2014.THE_GRID.Cliente values(@contador,@nombre,@apellido,'DNI',@dni,@mail,0,@nacimiento,'',@calle,@nro,@piso,@depto,'Sin_Localidad',@postal,'Sin_Ciudad')

set @contador = @contador + 1
fetch next from cursorCliente
 into @dni, @apellido, @nombre, @nacimiento, @mail, @calle, @nro, @piso, @depto, @postal
end
	----------FIN DEL WHILE
close cursorCliente
deallocate cursorCliente

------------------------------FIN DE CLIENTES -- INICIO DE EMPRESAS

declare @razon varchar(50) declare @cuit varchar(20) declare @creacion date

declare cursorEmpresa cursor for 
SELECT DISTINCT Publ_Empresa_Razon_Social,Publ_Empresa_Cuit,Publ_Empresa_Fecha_Creacion,Publ_Empresa_Mail,
Publ_Empresa_Dom_Calle,Publ_Empresa_Nro_Calle,Publ_Empresa_Piso,Publ_Empresa_Depto,Publ_Empresa_Cod_Postal
  FROM [GD1C2014].[gd_esquema].[Maestra]
  where Publ_Empresa_Razon_Social is not null;

open cursorEmpresa
fetch next from cursorEmpresa
 into @razon, @cuit, @creacion, @mail, @calle, @nro, @piso, @depto, @postal
	----------COMIENZO DEL WHILE
while(@@FETCH_STATUS = 0)
begin

insert into GD1C2014.THE_GRID.Usuario (Pass,Inhabilitado,Eliminado,ID_Tipo,Intentos, Primer_Ingreso, Datos_correctos) 
values('37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f',0,0,3,1,1,0)
insert into GD1C2014.THE_GRID.Roles_x_Usuario values(@contador,3,0)
insert into GD1C2014.THE_GRID.Empresa values(@contador,@razon,@cuit,@mail,0,@creacion,'Sin_Contacto',@calle,@nro,@piso,@depto,'Sin_Localidad',@postal,'Sin_Ciudad')

set @contador = @contador + 1
fetch next from cursorEmpresa
  into @razon, @cuit, @creacion, @mail, @calle, @nro, @piso, @depto, @postal
end
	----------FIN DEL WHILE
close cursorEmpresa
deallocate cursorEmpresa

------------------------------FIN DE EMPRESAS

insert into THE_GRID.Usuario(Pass,Inhabilitado,Eliminado,ID_Tipo,Intentos,Primer_Ingreso,Datos_Correctos) 
values('e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,0,1,1,0,1)

insert into THE_GRID.Administrador 
values ((select top 1 ID_User from THE_GRID.Usuario order by ID_User desc),'Administrador General')

insert into THE_GRID.Roles_x_Usuario (ID_User,ID_Rol,Inhabilitado) 
values ((select top 1 ID_User from THE_GRID.Usuario order by ID_User desc),1,0)

---------------------------------------------------------------------------------------------------------
--Visibilidades

declare visibilidades cursor for (SELECT DISTINCT Publicacion_Visibilidad_Desc,
	   Publicacion_Visibilidad_Precio, 
	   Publicacion_Visibilidad_Porcentaje
		from gd_esquema.Maestra
		where Publicacion_Visibilidad_Cod is not null)
declare @visibilidadNombre  varchar(256);
declare @visibilidadPrecio numeric(18,2);
declare @visibilidadPorcentaje  numeric(18,2);
declare @visibilidadTipo  numeric(18,0);

open visibilidades
fetch next from visibilidades into @visibilidadNombre,@visibilidadPrecio,@visibilidadPorcentaje
set @visibilidadTipo = 1;

while @@FETCH_STATUS = 0 begin
	insert into THE_GRID.Tipo_Visibilidad values(@visibilidadNombre)
	
	insert into THE_GRID.Visibilidad 
	values(@visibilidadNombre,@visibilidadPrecio,@visibilidadPorcentaje,7,0,@visibilidadTipo)
	fetch next from visibilidades into @visibilidadNombre,@visibilidadPrecio,@visibilidadPorcentaje
	set @visibilidadTipo = @visibilidadTipo + 1
end

close visibilidades
deallocate visibilidades

--------------------------- FIN VISIBILIDAD -- INICIO RUBRO

insert into THE_GRID.Rubro(Nombre)
SELECT DISTINCT Publicacion_Rubro_Descripcion
from gd_esquema.Maestra
where Publicacion_Rubro_Descripcion is not null

--------------------------- FIN RUBRO -- INICIO TIPO_PUBLICACION

insert into THE_GRID.Tipo_Publicacion(Nombre)
values('Compra Inmediata')
insert into THE_GRID.Tipo_Publicacion(Nombre)
values('Subasta')


--------------------------- FIN TIPO_PUBLICACION -- INICIO ESTADO_PUBLICACION

insert into THE_GRID.Estado_Publicacion(Nombre)
values('Publicada')
insert into THE_GRID.Estado_Publicacion(Nombre)
values('Borrador')
insert into THE_GRID.Estado_Publicacion(Nombre)
values('Pausada')
insert into THE_GRID.Estado_Publicacion(Nombre)
values('Finalizada')

--------------------------- FIN ESTADO_PUBLICACION

--Publicaciones

insert into THE_GRID.Publicacion

SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,
Publicacion_Fecha_Venc,Publicacion_Precio,Publicacion_Visibilidad_Cod, c.ID_User,
100,case when Publicacion_Tipo = 'Compra Inmediata' then 100
	when Publicacion_Tipo = 'Subasta' then 101 end,1,1

from gd_esquema.Maestra 
inner join THE_GRID.Cliente c on Publ_Cli_Dni = c.Documento
where Publ_Cli_Dni is not null 

union 

SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,
Publicacion_Fecha_Venc,Publicacion_Precio,Publicacion_Visibilidad_Cod, e.ID_User,
100,case when Publicacion_Tipo = 'Compra Inmediata' then 100
	when Publicacion_Tipo = 'Subasta' then 101 end,1,1

from gd_esquema.Maestra 
inner join THE_GRID.Empresa e on Publ_Empresa_Cuit = e.CUIT
where Publ_Empresa_Razon_Social is not null

order by Publicacion_Cod
go

------------------------------------------------------------------------------------------
--Rubros por Publicacion

insert into THE_GRID.Rubros_x_Publicacion
select distinct Publicacion_Cod, r.ID_Rubro  
from gd_esquema.Maestra
inner join THE_GRID.Rubro r on Publicacion_Rubro_Descripcion = r.Nombre
order by 1
go

------------------------------------------------------------------------------------------
--Facturas

insert into THE_GRID.Factura 

select Factura_Nro, THE_GRID.dameUserIDdni(Publ_Cli_Dni), Factura_Fecha, Forma_Pago_Desc, 0, Factura_Total
from gd_esquema.Maestra
where Publ_Cli_Dni is not null
group by Factura_Nro, Publ_Cli_Dni, Factura_Fecha, Forma_Pago_Desc, Factura_Total
having Factura_Nro is not null 

union

select Factura_Nro, THE_GRID.dameUserIDcuit(Publ_Empresa_Cuit), Factura_Fecha, Forma_Pago_Desc, 0, Factura_Total
from gd_esquema.Maestra
where Publ_Empresa_Cuit is not null
group by Factura_Nro, Publ_Empresa_Cuit, Factura_Fecha, Forma_Pago_Desc, Factura_Total
having Factura_Nro is not null 

order by Factura_Nro

------------------------------------------------------------------------------------------
--Renglones

insert into THE_GRID.RenglonFactura
select Factura_Nro, Publicacion_Cod, Item_Factura_Monto, Item_Factura_Cantidad 
from gd_esquema.Maestra where Factura_Nro is not null order by Factura_Nro

------------------------------------------------------------------------------------------
--Compras

insert into THE_GRID.Compra
select
m.Publicacion_Cod,
THE_GRID.dameUserIDdni(m.Cli_Dni), m.Compra_Cantidad, 
isnull( 
	(select MAX(x.Oferta_Monto) from gd_esquema.Maestra x where x.Publicacion_Cod = m.Publicacion_Cod) 
,m.Publicacion_Precio), 
m.Compra_Fecha, 1,
m.Calificacion_Cant_Estrellas, m.Calificacion_Descripcion

from gd_esquema.Maestra m

where 
m.Calificacion_Codigo is not null and
m.Compra_Fecha is not null
order by m.Compra_Fecha
go

-------------------------------------------------------------------------------------------
--Ofertas

insert into THE_GRID.Oferta 
select 
C.ID_User, X.Publicacion_Cod, case when c.ID_User = CO.ID_Comprador then 1 else 0 end,
X.Oferta_Fecha, X.Oferta_Monto

from  
gd_esquema.Maestra X
inner join THE_GRID.Cliente c ON X.Cli_Dni = c.Documento
inner join THE_GRID.Compra CO ON X.Publicacion_Cod = CO.ID_Publicacion

where 
X.Oferta_Fecha is not null
order by X.Oferta_Fecha

--------------------------------------------------------------------------------------------

