--------------------------- INICIO VISIBILIDAD
insert into TG.Visibilidad
select Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje
from gd_esquema.Maestra
where Publicacion_Visibilidad_Cod is not null
group by Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje
order by Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje desc

--------------------------- FIN VISIBILIDAD -- INICIO RUBRO

insert into TG.Rubro(Nombre)
select Publicacion_Rubro_Descripcion
from gd_esquema.Maestra
where Publicacion_Rubro_Descripcion is not null
group by Publicacion_Rubro_Descripcion

--------------------------- FIN RUBRO