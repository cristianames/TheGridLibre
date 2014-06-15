use GD1C2014
GO
create table GD1C2014.TG.Tipo_Usuario(
    ID_Tipo int identity(1,1) primary key,
    Nombre nvarchar(255) not null,
    Descripcion nvarchar(255)
)

create table GD1C2014.TG.Usuario(
	ID_User numeric(18,0) identity(1000,1) Primary key,
	Pass nvarchar(255),
	Inhabilitado bit,
	Antiguo bit,
	ID_Tipo int References TG.Tipo_Usuario(ID_Tipo),
	Intentos int,
	Primer_Ingreso bit
	
)

create table GD1C2014.TG.Cliente(
	ID_User numeric(18,0) references TG.Usuario(ID_User),
    Nombre nvarchar(255), 
    Apellido nvarchar(255),
    Tipo_Documento nvarchar(255), 
    Documento numeric(18,0),
    Mail nvarchar(255),
    Telefono numeric(18,0),
    Fecha_Nacimiento datetime, 
    Nro_Tarjeta numeric(20,0),
    Calle nvarchar(255), 
	Nro_Calle numeric(18,0), 
	Nro_Piso numeric(18,0), 
	Departamento nvarchar(50), 
	Localidad nvarchar(255),
	Cod_Postal nvarchar(50),
	Ciudad nvarchar(255)
    Primary Key(ID_User)
)

create table GD1C2014.TG.Empresa(
	ID_User numeric(18,0) references TG.Usuario(ID_User),
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

create table GD1C2014.TG.Administrador(
	ID_User numeric(18,0) references TG.Usuario(ID_User),
    Nombre nvarchar(255),
    Primary Key(ID_User)
)

create table GD1C2014.TG.Rol(
	ID_Rol numeric(18,0) identity(1,1) primary key,
	Nombre varchar(20) unique,
	Inhabilitado bit
)

create table GD1C2014.TG.Rubro(
	ID_Rubro numeric(18,0) identity(100,1) primary key,
	Nombre varchar(256) unique,
)

create table GD1C2014.TG.Visibilidad(
	ID_Visibilidad numeric(18,0) identity(10002,1) primary key,
	Nombre varchar(256),
	Precio_Por_Publicar numeric(18,2),
	Porcentaje_Venta numeric(18,2),
	Duracion numeric(3,0),
	Inhabilitado bit
)

create table GD1C2014.TG.Roles_x_Usuario(
	ID_User numeric(18,0) references TG.Usuario(ID_User),
	ID_Rol numeric(18,0) references TG.Rol(ID_Rol),
	Inhabilitado bit,
	Primary Key(ID_User,ID_Rol)
)

create table GD1C2014.TG.Funcionalidad(
	ID_Funcionalidad numeric(18,0) identity(1,1) primary key,
	Nombre nvarchar(255),
	Descripcion nvarchar(255)
)

create table GD1C2014.TG.Funcionalidades_x_Rol(
	ID_Rol numeric(18,0) references TG.Rol(ID_Rol),
	ID_Funcionalidad numeric(18,0) references TG.Funcionalidad(ID_Funcionalidad),
	Primary Key(ID_Rol,ID_Funcionalidad)
)

create table GD1C2014.TG.Publicacion(
	
    ID_Publicacion numeric(18,0) /*identity(1000000,1)*/ Primary Key,
	Descripcion nvarchar(255),
	Stock numeric(18,0),
	Fecha_Inicio datetime,
	Fecha_Vencimiento datetime,
	Precio numeric(18,2),
	ID_Visibilidad numeric(18,0) references TG.Visibilidad(ID_Visibilidad),
	ID_Vendedor numeric(18,0),
	ID_Rubro numeric(18,0) references TG.Rubro(ID_Rubro),
	Estado nvarchar(255),
	Tipo_Publicacion nvarchar(255),
	Permitir_Preuntas bit,		
	Foreign Key(ID_Vendedor) references TG.Usuario(ID_User)	
)

create table GD1C2014.TG.Factura(
	ID_Factura numeric(18,0) /*identity(100000,1)*/ primary key,
	ID_Publicacion numeric(18,0) references TG.Publicacion(ID_Publicacion),
	Fecha date,
	Forma_Pago nvarchar(255),
	Nro_Tarjeta numeric(20,0),
	Total numeric(18,0)
)

create table GD1C2014.TG.Oferta(
	ID_Oferta numeric(18,0) identity(1000000,1) Primary Key,
	ID_Ofertante numeric(18,0) references TG.Usuario(ID_User),
	ID_Publicacion numeric(18,0) references TG.Publicacion(ID_Publicacion),
	Concretada bit,
	Fecha_Oferta date,
	Monto_Oferta numeric(18,0),
)

create table GD1C2014.TG.Compra(
	ID_Operacion numeric(18,0) identity(1000000,1) Primary Key,
	ID_Factura numeric(18,0) references TG.Factura(ID_Factura),
	ID_Publicacion numeric(18,0) references TG.Publicacion(ID_Publicacion),
	ID_Comprador numeric(18,0) references TG.Usuario(ID_User),
	Item_Cantidad numeric(18,0),
	Item_Monto numeric(18,2),
	Fecha date,
	Pagada bit,
	Calif_Estrellas numeric(18,0),
	Calif_Detalle nvarchar(255),
)

create table GD1C2014.TG.Pregunta(
	ID_Pregunta numeric(18,0) identity(1000000,1) Primary Key,
	ID_Publicacion numeric(18,0) references TG.Publicacion(ID_Publicacion),
	Pregunta nvarchar(255),
	Fecha_Pregunta date,
	Respuesta nvarchar(255),
	Fecha_Respuesta date
)

GO

insert into TG.Rol(Nombre,Inhabilitado) values('Administrador',0)
insert into TG.Rol(Nombre,Inhabilitado) values('Comprador',0)
insert into TG.Rol(Nombre,Inhabilitado) values('Vendedor',0)

insert into TG.Tipo_Usuario(Nombre,Descripcion) values('Administrador','Administrador General')
insert into TG.Tipo_Usuario(Nombre,Descripcion) values('Cliente','Usuario individual, comprador y vendedor')
insert into TG.Tipo_Usuario(Nombre,Descripcion) values('Empresa','Empresa, solo vendedor')

--Funcionalidades -----------------------------------------------------------------------
insert into TG.Funcionalidad(Nombre,Descripcion)
values('ABM Usuario','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('ABM Cliente','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('ABM Empresa','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('ABM Rol','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('ABM Rubro','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('ABM Visibilidad','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Listado Estadistico','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Calificar Vendedor','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Comprar - Ofertar','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Editar Publicacion','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Facturar Publicaciones','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Generar Publicacion','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Gestion De Preguntas','Soy una descripcion')

insert into TG.Funcionalidad(Nombre,Descripcion)
values('Historial del Cliente','Soy una descripcion')

--Funcionalidades por Rol -------------------------------

insert into TG.Funcionalidades_x_Rol
select 1,ID_Funcionalidad from TG.Funcionalidad

------------------------------------------------------------------------------------

insert into TG.Funcionalidades_x_Rol 
values(2,8)

insert into TG.Funcionalidades_x_Rol 
values(2,9)

insert into TG.Funcionalidades_x_Rol 
values(2,14)

------------------------------------------------------------------------------------

insert into TG.Funcionalidades_x_Rol 
values(3,10)

insert into TG.Funcionalidades_x_Rol 
values(3,11)

insert into TG.Funcionalidades_x_Rol 
values(3,12)

insert into TG.Funcionalidades_x_Rol 
values(3,13)

GO
