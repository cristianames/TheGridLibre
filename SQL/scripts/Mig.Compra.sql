--use GD1C2014
--go
insert into TG.Compra
select
f.ID_Factura, m.Publicacion_Cod,
TG.dameUserIDdni(m.Cli_Dni), m.Compra_Cantidad, m.Publicacion_Precio, m.Compra_Fecha, 1,
m.Calificacion_Cant_Estrellas, m.Calificacion_Descripcion

from gd_esquema.Maestra m inner join TG.Factura f on m.Publicacion_Cod = f.ID_Publicacion

where 
m.Calificacion_Codigo is not null and
m.Compra_Fecha is not null
order by m.Compra_Fecha
go