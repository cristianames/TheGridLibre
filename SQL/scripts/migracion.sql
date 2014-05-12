declare @infoTemporal table(
    ID_User numeric(18,0) Identity(1000,1),
/*  Pass varchar(20),
    Inhabilitado bit, 
    Antiguo bit,
*/  ID_Rol numeric(18,0),
    
    Razon_Social nvarchar(255),
    Nombre nvarchar(255), 
    Apeliido nvarchar(255),
    Tipo_Documento varchar(16), 
    Documento_CUIT numeric(18,0),
    Mail nvarchar(255),
    Telefono numeric(18,0),
    Fecha_Inicial datetime, 
    Nro_Tarjeta numeric(20,0),
    
	Dom_Calle nvarchar(255), 
	Nro_Calle numeric(18,0), 
	Nro_Piso numeric(18,0), 
	Departamento nvarchar(50), 
	Localidad varchar(20),
	Cod_Postal  nvarchar(50),
	Ciudad varchar(20)
)

--------- BARRIDA DE CLIENTES --------------
insert into @infoTemporal
	SELECT 
		2, NULL, Publ_Cli_Nombre, Publ_Cli_Apeliido, 'DNI', Publ_Cli_Dni,   
		Publ_Cli_Mail, NULL, Publ_Cli_Fecha_Nac, NULL, Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, 
		Publ_Cli_Piso, Publ_Cli_Depto, NULL, Publ_Cli_Cod_Postal, NULL
	FROM [GD1C2014].[gd_esquema].[Maestra]
--	where Publ_Cli_Dni is not null
	group by 
		Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail, 
		Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal
	having 
		Publ_Cli_Dni is not null

--delete from @infoTemporal;
--Al poner el delete, no altera el autoincremental
--insert into @infoTemporal (ID_Rol) values(2) 
--select * from @infoTemporal

declare @contador int
declare @tope int
set @contador = 0
set @tope = (select COUNT(*) from @infoTemporal)

while(@contador < @tope)
	begin
	insert into GD1C2014.dbo.TG_Usuario (Pass,Inhabilitado,Antiguo) values('Zaraza',0,1)
	insert into GD1C2014.dbo.TG_Roles_x_Usuario (ID_User,ID_Rol) values(1000+@contador,2)
	set @contador = @contador + 1
end

insert into GD1C2014.dbo.TG_Informacion
select ID_User,ID_Rol,Razon_Social,Nombre,Apeliido,Tipo_Documento,
Documento_CUIT,Mail,Telefono,Fecha_Inicial,Nro_Tarjeta from @infoTemporal

insert into GD1C2014.dbo.TG_Direccion
select ID_User,ID_Rol,Dom_Calle,Nro_Calle,Nro_Piso,Departamento, 
	Localidad, Cod_Postal, Ciudad from @infoTemporal
	
delete from @infoTemporal;

--------- BARRIDA DE EMPRESAS --------------
insert into @infoTemporal
	SELECT 
		1, NULL, Publ_Empresa_Razon_Social, NULL, 'CUIT', Publ_Empresa_Cuit, Publ_Empresa_Mail, 
		NULL, Publ_Empresa_Fecha_Creacion, NULL, Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle,	
		Publ_Empresa_Piso, Publ_Empresa_Depto, NULL, Publ_Empresa_Cod_Postal, NULL
	FROM [GD1C2014].[gd_esquema].[Maestra]
	group by 
		Publ_Empresa_Razon_Social, Publ_Empresa_Cuit, Publ_Empresa_Mail, 
		Publ_Empresa_Fecha_Creacion, Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle,	
		Publ_Empresa_Piso, Publ_Empresa_Depto, Publ_Empresa_Cod_Postal
	having 
		Publ_Empresa_Cuit is not null
		

set @contador = @tope
set @tope = @tope + (select COUNT(*) from @infoTemporal)

while(@contador < @tope)
	begin
	insert into GD1C2014.dbo.TG_Usuario (Pass,Inhabilitado,Antiguo) values('ZarazaMasPiola',0,1)
	insert into GD1C2014.dbo.TG_Roles_x_Usuario (ID_User,ID_Rol) values(1000+@contador,1)
	set @contador = @contador + 1
end

insert into GD1C2014.dbo.TG_Informacion
select ID_User,ID_Rol,Razon_Social,Nombre,Apeliido,Tipo_Documento,
Documento_CUIT,Mail,Telefono,Fecha_Inicial,Nro_Tarjeta from @infoTemporal

insert into GD1C2014.dbo.TG_Direccion
select ID_User,ID_Rol,Dom_Calle,Nro_Calle,Nro_Piso,Departamento, 
	Localidad, Cod_Postal, Ciudad from @infoTemporal