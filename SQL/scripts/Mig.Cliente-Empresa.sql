------------------------------ INICIO DE CLIENTES
use GD1C2014
go
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

insert into GD1C2014.TG.Usuario (Pass,Inhabilitado,Antiguo,ID_Tipo,Intentos, Primer_Ingreso) values('37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f',0,1,2,1,1)
insert into GD1C2014.TG.Roles_x_Usuario values(@contador,2,0)
insert into GD1C2014.TG.Cliente values(@contador,@nombre,@apellido,'DNI',@dni,@mail,0,@nacimiento,0,@calle,@nro,@piso,@depto,'Sin_Localidad',@postal,'Sin_Ciudad')

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

insert into GD1C2014.TG.Usuario (Pass,Inhabilitado,Antiguo,ID_Tipo,Intentos, Primer_Ingreso) values('37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f',0,1,3,1,1)
insert into GD1C2014.TG.Roles_x_Usuario values(@contador,3,0)
insert into GD1C2014.TG.Empresa values(@contador,@razon,@cuit,@mail,0,@creacion,'Sin_Contacto',@calle,@nro,@piso,@depto,'Sin_Localidad',@postal,'Sin_Ciudad')

set @contador = @contador + 1
fetch next from cursorEmpresa
  into @razon, @cuit, @creacion, @mail, @calle, @nro, @piso, @depto, @postal
end
	----------FIN DEL WHILE
close cursorEmpresa
deallocate cursorEmpresa

------------------------------FIN DE EMPRESAS