insert into TG.Compra
select
m.Publicacion_Cod,
TG.dameUserIDdni(m.Cli_Dni), m.Compra_Cantidad, m.Publicacion_Precio, m.Compra_Fecha, 1,
m.Calificacion_Cant_Estrellas, m.Calificacion_Descripcion

from gd_esquema.Maestra m

where 
m.Calificacion_Codigo is not null and
m.Compra_Fecha is not null
order by m.Compra_Fecha
go