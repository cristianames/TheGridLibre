create table GD1C2014.dbo.TG_Usuario(
	ID_User numeric(18,0) identity(1000,1) Primary key,
--	Username varchar(80) unique,
	Pass varchar(20),
	Inhabilitado bit,
	Antiguo bit
)

create table GD1C2014.dbo.TG_Rol(
	ID_Rol numeric(18,0) identity(1,1) primary key,
	Nombre varchar(20) unique,
	Inhabilitado bit
)

create table GD1C2014.dbo.TG_Rubro(
	ID_Rubro numeric(18,0) identity(1,1) primary key,
	Nombre varchar(20) unique,
	Descripcion varchar(50)
)

create table GD1C2014.dbo.TG_Visibilidad(
	ID_Visibilidad numeric(18,0) identity(1,1) primary key,
	Nombre varchar(20) unique,
	Descripcion varchar(50),
	Precio_Por_Publicar numeric(18,0),
	Porcentaje_Venta numeric(18,0)
)

create table GD1C2014.dbo.TG_Factura(
	ID_Factura numeric(18,0) identity(100000,1) primary key,
	Fecha date,
	Forma_Pago varchar(30),
	Nro_Tarjeta numeric(20,0)
)
create table GD1C2014.dbo.TG_Roles_x_Usuario(
	ID_User numeric(18,0) references TG_Usuario(ID_User),
	ID_Rol numeric(18,0) references TG_Rol(ID_Rol),
	Inhabilitado bit,
	Primary Key(ID_User,ID_Rol)
)

create table GD1C2014.dbo.TG_Funcionalidades_x_Rol(
	ID_Rol numeric(18,0) references TG_Rol(ID_Rol) Primary Key,
	Nombre varchar(20),
	Descripcion varchar(50)
)

create table GD1C2014.dbo.TG_Caracteristicas_x_Rol(
	ID_Rol numeric(18,0) references TG_Rol(ID_Rol) Primary Key,
	Caracteristicas varchar(50)
)

create table GD1C2014.dbo.TG_Informacion(
	ID_User numeric(18,0),
	ID_Rol numeric(18,0),
	Razon_Social nvarchar(255),
        Nombre nvarchar(255), 
        Apeliido nvarchar(255),
        Tipo_Documento varchar(16), 
        Documento_CUIT numeric(18,0),
        Mail nvarchar(255),
        Telefono numeric(18,0),
        Fecha_Inicial datetime, 
        Nro_Tarjeta numeric(20,0),
	Primary Key(ID_User,ID_Rol),
	Foreign Key(ID_User,ID_Rol) references TG_Roles_x_Usuario(ID_User,ID_Rol)
)

create table GD1C2014.dbo.TG_Direccion(
	ID_User numeric(18,0),
	ID_Rol numeric(18,0),
	Dom_Calle nvarchar(255), 
	Nro_Calle numeric(18,0), 
	Nro_Piso numeric(18,0), 
	Departamento nvarchar(50), 
	Localidad varchar(20),
	Cod_Postal nvarchar(50),
	Ciudad varchar(20),
	Primary Key(ID_User,ID_Rol),	
	Foreign Key(ID_User,ID_Rol) references TG_Roles_x_Usuario(ID_User,ID_Rol)
)

create table GD1C2014.dbo.TG_Publicacion(
	ID_Publicacion numeric(18,0) identity(1000000,1) Primary Key,
	Descripcion varchar(50),
	Stock numeric(18,0),
	Fecha_Inicio date,
	Fecha_Vencimiento date,
	Precio numeric(18,0),
	ID_Visibilidad numeric(18,0) references TG_Visibilidad(ID_Visibilidad),
	ID_Vendedor numeric(18,0),
	ID_Rol numeric(18,0),
	Estado varchar(2) check(Estado in ('B','A','P','F')),
	Tipo_Publicacion varchar(2) check(Tipo_Publicacion in ('C','S')),
	Permitir_Preuntas bit,		
	Foreign Key(ID_Vendedor,ID_Rol) references TG_Roles_x_Usuario(ID_User,ID_Rol)	
)

create table GD1C2014.dbo.TG_Oferta(
	ID_Oferta numeric(18,0) identity(1000000,1) Primary Key,
	ID_Ofertante numeric(18,0) references TG_Usuario(ID_User),
	ID_Publicacion numeric(18,0) references TG_Publicacion(ID_Publicacion),
	Concretada bit,
	Fecha_Oferta date,
	Monto_Oferta numeric(18,0),
)

create table GD1C2014.dbo.TG_Compra(
	ID_Operacion numeric(18,0) identity(1000000,1) Primary Key,
	ID_Comprador numeric(18,0) references TG_Usuario(ID_User),
	ID_Factura numeric(18,0) references TG_Factura(ID_Factura),
	ID_Publicacion numeric(18,0) references TG_Publicacion(ID_Publicacion),
	ID_Vendedor numeric(18,0) references TG_Usuario(ID_User),
	Cantidad numeric(18,0),
	Fecha date,
	Pagada bit,
	Calificacion numeric(18,0),
	Detalle varchar(50)
)

create table GD1C2014.dbo.TG_Publicaciones_x_Rubro(
	ID_Rubro numeric(18,0) references TG_Rubro(ID_Rubro),
	ID_Publicacion numeric(18,0) references TG_Publicacion(ID_Publicacion),
	Primary Key(ID_Rubro,ID_Publicacion)
)

create table GD1C2014.dbo.TG_Preguntas(
	ID_Pregunta numeric(18,0) identity(1000000,1) Primary Key,
	ID_Publicacion numeric(18,0) references TG_Publicacion(ID_Publicacion),
	Pregunta varchar(256),
	Fecha_Pregunta date,
	Respuesta varchar(256),
	Fecha_Respuesta date
)

insert into GD1C2014.dbo.TG_Rol(Nombre,Inhabilitado) values('Administrador',0)
insert into GD1C2014.dbo.TG_Rol(Nombre,Inhabilitado) values('Cliente',0)
insert into GD1C2014.dbo.TG_Rol(Nombre,Inhabilitado) values('Empresa',0)
