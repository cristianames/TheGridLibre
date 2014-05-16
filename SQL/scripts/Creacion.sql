create table GD1C2014.TG.Tipo_Usuario(
    ID_Tipo int identity(1,1) primary key,
    Nombre nvarchar(20) not null,
    Descripcion nvarchar(50)
)

create table GD1C2014.TG.Usuario(
	ID_User numeric(18,0) identity(1000,1) Primary key,
	Pass varchar(256),
	Inhabilitado bit,
	Antiguo bit,
	ID_Tipo int References TG.Tipo_Usuario(ID_Tipo)
)

create table GD1C2014.TG.Cliente(
	ID_User numeric(18,0),
    Nombre nvarchar(255), 
    Apellido nvarchar(255),
    Tipo_Documento varchar(16), 
    Documento numeric(18,0),
    Mail nvarchar(255),
    Telefono numeric(18,0),
    Fecha_Nacimiento datetime, 
    Nro_Tarjeta numeric(20,0),
    Calle nvarchar(255), 
	Nro_Calle numeric(18,0), 
	Nro_Piso numeric(18,0), 
	Departamento nvarchar(50), 
	Localidad varchar(20),
	Cod_Postal nvarchar(50),
	Ciudad varchar(20)
	Primary Key(ID_User)
)

create table GD1C2014.TG.Empresa(
	ID_User numeric(18,0),
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
	Ciudad varchar(20)
	Primary Key(ID_User)
)

create table GD1C2014.TG.Administrador(
  ID_User numeric(18,0),
    Nombre nvarchar(255),
    Primary Key(ID_User)
)

create table GD1C2014.TG.Rol(
	ID_Rol numeric(18,0) identity(1,1) primary key,
	Nombre varchar(20) unique,
	Inhabilitado bit
)

create table GD1C2014.TG.Rubro(
	ID_Rubro numeric(18,0) primary key,
	Nombre varchar(256) unique,
)

create table GD1C2014.TG.Visibilidad(
	ID_Visibilidad numeric(18,0) primary key,
	Nombre varchar(256) unique,
	Precio_Por_Publicar numeric(18,0),
	Porcentaje_Venta numeric(18,0)
)

create table GD1C2014.TG.Factura(
	ID_Factura numeric(18,0) identity(100000,1) primary key,
	Fecha date,
	Forma_Pago varchar(30),
	Nro_Tarjeta numeric(20,0),
	Total numeric(18,0)
)
create table GD1C2014.TG.Roles_x_Usuario(
	ID_User numeric(18,0) references TG.Usuario(ID_User),
	ID_Rol numeric(18,0) references TG.Rol(ID_Rol),
	Inhabilitado bit,
	Primary Key(ID_User,ID_Rol)
)

create table GD1C2014.TG.Funcionalidades_x_Rol(
	ID_Rol numeric(18,0) references TG.Rol(ID_Rol) Primary Key,
	Nombre varchar(20),
	Descripcion varchar(50)
)

create table GD1C2014.TG.Publicacion(
	ID_Publicacion numeric(18,0) identity(1000000,1) Primary Key,
	Descripcion varchar(50),
	Stock numeric(18,0),
	Fecha_Inicio date,
	Fecha_Vencimiento date,
	Precio numeric(18,0),
	ID_Visibilidad numeric(18,0) references TG.Visibilidad(ID_Visibilidad),
	ID_Vendedor numeric(18,0),
	ID_Rol numeric(18,0),
	ID_Rubro numeric(18,0) references TG.Rubro(ID_Rubro),
	Estado varchar(2) check(Estado in ('B','A','P','F')),
	Tipo_Publicacion varchar(2) check(Tipo_Publicacion in ('C','S')),
	Permitir_Preuntas bit,		
	Foreign Key(ID_Vendedor) references TG.Usuario(ID_User)	
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
	ID_Comprador numeric(18,0) references TG.Usuario(ID_User),
	ID_Factura numeric(18,0) references TG.Factura(ID_Factura),
	ID_Publicacion numeric(18,0) references TG.Publicacion(ID_Publicacion),
	ID_Vendedor numeric(18,0) references TG.Usuario(ID_User),
	Item_Cantidad numeric(18,0),
	Item_Monto numeric(18,2),
	Fecha date,
	Pagada bit,
	Calif_Estrellas numeric(18,0),
	Calif_Detalle varchar(50),
)

create table GD1C2014.TG.Pregunta(
	ID_Pregunta numeric(18,0) identity(1000000,1) Primary Key,
	ID_Publicacion numeric(18,0) references TG.Publicacion(ID_Publicacion),
	Pregunta varchar(256),
	Fecha_Pregunta date,
	Respuesta varchar(256),
	Fecha_Respuesta date
)

insert into TG.Rol(Nombre,Inhabilitado) values('Administrador',0)
insert into TG.Rol(Nombre,Inhabilitado) values('Comprador',0)
insert into TG.Rol(Nombre,Inhabilitado) values('Vendedor',0)

insert into TG.Tipo_Usuario(Nombre) values('Administrador')
insert into TG.Tipo_Usuario(Nombre) values('Cliente')
insert into TG.Tipo_Usuario(Nombre) values('Empresa')
