--------------------------- INICIO PUBLICACION

insert into TG.Publicacion
SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,
Publicacion_Visibilidad_Cod,C.ID_User,ID_Rubro,Publicacion_Estado,Publicacion_Tipo,1
from gd_esquema.Maestra,TG.Visibilidad,TG.Rubro R,TG.Cliente C
where Publ_Cli_Dni is not null and R.Nombre = Publicacion_Rubro_Descripcion and C.Documento = Publ_Cli_Dni
union 
SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,
Publicacion_Visibilidad_Cod,E.ID_User,ID_Rubro,Publicacion_Estado,Publicacion_Tipo,1
from gd_esquema.Maestra,TG.Visibilidad,TG.Rubro R,TG.Empresa E
where Publ_Empresa_Razon_Social is not null and R.Nombre = Publicacion_Rubro_Descripcion and E.Razon_Social = Publ_Empresa_Razon_Social
order by Publicacion_Cod

--------------------------- FIN PUBLICACION

/*
Deberia tener algo parecido el procedure para insertar una nueva publicacion
DECLARE @ID_AUXILIAR INT
IF(SELECT COUNT(*) FROM  TABLA )= 0
	BEGIN
		SET @ID_AUXILIAR = 1
	END
ELSE
	BEGIN
		DECLARE @ID_MAX INT
		SET @ID_MAX=(SELECT MAX(NU_ID)
						FROM TABLA  )
		SET @ID_AUXILIAR = @ID_MAX + 1
END
*/
