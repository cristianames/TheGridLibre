create table pruebasDeScript.dbo.Rol(
	ID_Rol numeric(18,0) identity(1,1) primary key,
	Nombre_Rol varchar(20) unique,
	Inhabilitado bit
)

create table pruebasDeScript.dbo.Usuario(
	ID_User numeric(18,0) identity(1000,1) Primary key,
	Username varchar(20) unique,
	Pass varchar(50),
	Inhabilitado bit,
	Antiguo bit
)

create table pruebasDeScript.dbo.Roles_x_Usuario(
	ID_User numeric(18,0) references Usuario(ID_User),
	ID_Rol numeric(18,0) references Rol(ID_Rol),
	Inhabilitado bit,
	Primary Key(ID_User,ID_Rol)
)