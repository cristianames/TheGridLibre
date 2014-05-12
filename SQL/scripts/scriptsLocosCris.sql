create view Clientes(Pass, Inhabilitado, Antiguo, iID_Rol, Razon_Social, 
Nombre, Apellido, Tipo_Documento, Documento_CUIT, Mail, Telefono, Fecha_Inicial, Nro_Tarjeta, 
dID_Rol, Dire_Calle, Nro_Calle, Nro_Piso, Departamento, Localidad, Cod_Postal, Ciudad) 
as select u.Pass, u.Inhabilitado, u.Antiguo,
i.ID_Rol, i.Razon_Social, i.Nombre, i.Apellido, i.Tipo_Documento, i.Documento_CUIT, i.Mail, i.Telefono, 
i.Fecha_Inicial, i.Nro_Tarjeta,
d.ID_Rol, d.Dire_Calle, d.Nro_Calle, d.Nro_Piso, d.Departamento, d.Localidad, d.Cod_Postal, d.Ciudad
from 
	dbo.TG_Usuario u, 
	dbo.TG_Informacion i, 
	dbo.TG_Direccion d

drop view Clientes
select * from Clientes
	
insert into Clientes
SELECT 'zaraza', 0, 1, 2, NULL, Publ_Cli_Nombre, Publ_Cli_Apeliido, 'DNI', Publ_Cli_Dni,   
Publ_Cli_Mail, NULL, Publ_Cli_Fecha_Nac, NULL, 2, Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, 
Publ_Cli_Depto, NULL, Publ_Cli_Cod_Postal, NULL
  FROM [GD1C2014].[gd_esquema].[Maestra]
  where Publ_Cli_Dni is not null
  group by Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal



insert into GD1C2014.dbo.TG_Direccion(ID_Rol,Dire_Calle, Nro_Calle, Nro_Piso,
Departamento,Localidad,Cod_Postal,Ciudad)
SELECT 2, Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, 
Publ_Cli_Depto, NULL, Publ_Cli_Cod_Postal, NULL
FROM [GD1C2014].[gd_esquema].[Maestra]
  where Publ_Cli_Dni is not null
  group by Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal

insert into GD1C2014.dbo.TG_Informacion(ID_Rol,Razon_Social,Nombre,Apellido,Tipo_Documento,Documento_CUIT,Mail,
Telefono,Fecha_Inicial,Nro_Tarjeta)
SELECT ROW_NUMBER() over(order by Publ_Cli_DNI desc),2, NULL, Publ_Cli_Nombre, Publ_Cli_Apeliido, 'DNI', Publ_Cli_Dni,  
Publ_Cli_Mail, NULL, Publ_Cli_Fecha_Nac, NULL
FROM [GD1C2014].[gd_esquema].[Maestra]
  where Publ_Cli_Dni is not null
  group by Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal

BEGIN
declare @dni int declare @apellido varchar(15) declare @nombre varchar(15) 
declare @nacimiento date declare @mail varchar(30) declare @calle varchar(64) 
declare @nro int declare @piso int declare @depto varchar(16) declare @postal int
declare @contador int declare @rol int declare @tope int declare @aux bigint
set @contador=0
set @rol=2
set @tope = (select COUNT(distinct Publ_Cli_Dni)  from [GD1C2014].[gd_esquema].[Maestra] where Publ_Cli_Dni is not null)

while @contador < @tope  begin

SELECT @nombre=Publ_Cli_Nombre, @apellido=Publ_Cli_Apeliido, @dni=Publ_Cli_Dni,  
@mail=Publ_Cli_Mail, @nacimiento=Publ_Cli_Fecha_Nac, @calle=Publ_Cli_Dom_Calle, 
@nro=Publ_Cli_Nro_Calle, @piso=Publ_Cli_Piso, @depto=Publ_Cli_Depto,@postal=Publ_Cli_Cod_Postal
  FROM [GD1C2014].[gd_esquema].[Maestra]
  where 
	Publ_Cli_Dni is not null  
  group by Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal
insert into GD1C2014.dbo.TG_Usuario(Pass,Inhabilitado,Antiguo)values('Zaraza',0,1)
insert into GD1C2014.dbo.TG_Roles_x_Usuario(ID_User,ID_Rol,Inhabilitado) values(@contador+1000,@rol,1)
insert into GD1C2014.dbo.TG_Informacion(ID_User,ID_Rol,Razon_Social,Nombre,Apellido,Tipo_Documento, Documento_CUIT,Mail,Telefono,Fecha_Inicial,Nro_Tarjeta) 
 	values(@contador+1000,@rol,NULL,@nombre,@apellido,'DNI',@dni,@mail,NULL,@nacimiento,NULL)
insert into GD1C2014.dbo.TG_Direccion(ID_User,ID_Rol,Dire_Calle,Nro_Calle,Nro_Piso,Departamento,Localidad,Cod_Postal,Ciudad) 
 	values(@contador+1000,@rol,@calle,@nro,@piso,@depto,NULL,@postal,NULL)
 	set @contador = @contador + 1
end

End

/****** Script para el comando SelectTopNRows de SSMS  ******/

SELECT Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal
  FROM [GD1C2014].[gd_esquema].[Maestra]
  where Publ_Cli_Dni is not null
  group by Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal



create view Clientes as
select u.ID_User, u.Pass, u.Inhabilitado, u.Antiguo,
i.ID_User, i.ID_Rol, i.Razon_Social, i.Nombre, i.Apellido, i.Tipo_Documento, i.Documento_CUIT, i.Mail, i.Telefono, 
i.Fecha_Inicial, i.Nro_Tarjeta,
d.ID_User, d.ID_Rol, d.Dire_Calle, d.Nro_Piso, d.Departamento, d.Localidad, d.Cod_Postal, d.Ciudad
from dbo.TG_Usuario u, dbo.TG_Informacion i, dbo.TG_Direccion d