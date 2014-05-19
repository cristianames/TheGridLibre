--------------------------- INICIO PUBLICACION
use GD1C2014
go
insert into TG.Publicacion

SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,
Publicacion_Fecha_Venc,Publicacion_Precio,Publicacion_Visibilidad_Cod, c.ID_User,
r.ID_Rubro,Publicacion_Estado,Publicacion_Tipo,1

from gd_esquema.Maestra 
inner join TG.Cliente c on Publ_Cli_Dni = c.Documento
inner join TG.Rubro r on Publicacion_Rubro_Descripcion = r.Nombre
where Publ_Cli_Dni is not null 

union 

SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,
Publicacion_Fecha_Venc,Publicacion_Precio,Publicacion_Visibilidad_Cod, e.ID_User,
r.ID_Rubro,Publicacion_Estado,Publicacion_Tipo,1

from gd_esquema.Maestra 
inner join TG.Empresa e on Publ_Empresa_Cuit = e.CUIT
inner join TG.Rubro r on Publicacion_Rubro_Descripcion = r.Nombre
where Publ_Empresa_Razon_Social is not null

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
