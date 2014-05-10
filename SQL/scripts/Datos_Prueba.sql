insert into GD1C2014.dbo.TG_Usuario(Username,Pass,Inhabilitado,Antiguo) values('DanteKpo','',0,1)
insert into GD1C2014.dbo.TG_Usuario(Username,Pass,Inhabilitado,Antiguo) values('James','',0,1)
insert into GD1C2014.dbo.TG_Usuario(Username,Pass,Inhabilitado,Antiguo) values('Rikuo','',0,1)
insert into GD1C2014.dbo.TG_Usuario(Username,Pass,Inhabilitado,Antiguo) values('Surakituaka','',0,1)
insert into GD1C2014.dbo.TG_Usuario(Username,Pass,Inhabilitado,Antiguo) values('Izikiel','',0,1)
insert into GD1C2014.dbo.TG_Usuario(Username,Pass,Inhabilitado,Antiguo) values('Josiu','',0,1)

insert into GD1C2014.dbo.TG_Rol(Nombre,Inhabilitado) values('Administrado',0)
insert into GD1C2014.dbo.TG_Rol(Nombre,Inhabilitado) values('Cliente',0)
insert into GD1C2014.dbo.TG_Rol(Nombre,Inhabilitado) values('Empresa',0)

insert into GD1C2014.dbo.TG_Rubro(Nombre,Descripcion) values('Electronica','Articulos electronicos.')
insert into GD1C2014.dbo.TG_Rubro(Nombre,Descripcion) values('Modelismo','Lo que yo colecciono.')
insert into GD1C2014.dbo.TG_Rubro(Nombre,Descripcion) values('Deportes','Lo que Dante no hace.')

insert into GD1C2014.dbo.TG_Visibilidad(Nombre,Descripcion,Precio_Por_Publicar,Porcentaje_Venta) values('Platino','Visibilidad mas alta',100,5)
insert into GD1C2014.dbo.TG_Visibilidad(Nombre,Descripcion,Precio_Por_Publicar,Porcentaje_Venta) values('Oro','Segunda Visibilidad',60,10)
insert into GD1C2014.dbo.TG_Visibilidad(Nombre,Descripcion,Precio_Por_Publicar,Porcentaje_Venta) values('Plata','Tercera Visibilidad',40,15)
insert into GD1C2014.dbo.TG_Visibilidad(Nombre,Descripcion,Precio_Por_Publicar,Porcentaje_Venta) values('Bronce','Cuarta Visibilidad',20,25)
insert into GD1C2014.dbo.TG_Visibilidad(Nombre,Descripcion,Precio_Por_Publicar,Porcentaje_Venta) values('Gratis','Visibilidad Gratuita',0,0)

insert into GD1C2014.dbo.TG_Factura(Fecha,Forma_Pago,Nro_Tarjeta) values('15-12-2012','Efectivo',NULL)
insert into GD1C2014.dbo.TG_Factura(Fecha,Forma_Pago,Nro_Tarjeta) values('07-01-2013','Efectivo',NULL)
insert into GD1C2014.dbo.TG_Factura(Fecha,Forma_Pago,Nro_Tarjeta) values('19-05-2013','Tarjeta de credito',123412341234)
insert into GD1C2014.dbo.TG_Factura(Fecha,Forma_Pago,Nro_Tarjeta) values('22-06-2013','Tarjeta de credito',123412341234)
insert into GD1C2014.dbo.TG_Factura(Fecha,Forma_Pago,Nro_Tarjeta) values('01-07-2013','Efectivo',NULL)

insert into GD1C2014.dbo.TG_Roles_x_Usuario(ID_User,ID_Rol,Inhabilitado) values()

insert into GD1C2014.dbo.TG_Funcionalidades_x_Rol(ID_Rol,Nombre,Descripcion) values()

insert into GD1C2014.dbo.TG_Caracteristicas_x_Rol(ID_Rol,Caracteristica) values()

insert into GD1C2014.dbo.TG_Informacion(ID_User,ID_Rol,Razon_Social,Nombre,Apellido,Tipo_Documento,Documento_CUIT,Mail,Telefono,Fecha_Inicial,Nro_Tarjeta) values()

insert into GD1C2014.dbo.TG_Direccion(ID_User,ID_Rol,Dire_Calle,Nro_Piso,Departamento,Localidad,Cod_Postal,Ciudad) values()

insert into GD1C2014.dbo.TG_Publicacion(Descripcion,Stock,Fecha_Inicio,Fecha_Vencimiento,Precio,ID_Visibilidad,ID_Vendedor,ID_Rol,Estado,Tipo_Publicacion,Permitir_Preguntas) values()

insert into GD1C2014.dbo.TG_Oferta(ID_Ofertante,ID_Publicacion,Concretada,Fecha_Oferta,Monto_Oferta) values()

insert into GD1C2014.dbo.TG_Compra(ID_Comprador,ID_Facura,ID_Publicacion,ID_Vendedor,Cantidad,Fecha,Pagada,Calificacion,Detalle) values())

insert into GD1C2014.dbo.TG_Publicaciones_x_Rubro(ID_Rubro,ID_Publicacion) values()

insert into GD1C2014.dbo.TG_Preguntas(ID_Publicacion,Pregunta,Fecha_Pregunta,Respuesta,Fecha_Respuesta) values()