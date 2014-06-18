
create view TG.Estad_Productos as
select U.ID_User Usuario,(SUM(P.Stock)) as Cantidad, V.Nombre Visibilidad, V.Precio_Por_Publicar Precio_Visibilidad, 
MONTH(P.Fecha_Inicio) as Mes,
(case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end) as Trimestre,
YEAR(P.Fecha_Inicio) as Anio
from TG.Usuario U, TG.Publicacion P, TG.Visibilidad V
where P.ID_Vendedor = U.ID_User and P.ID_Visibilidad = V.ID_Visibilidad
group by YEAR(P.Fecha_Inicio), (case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end), MONTH(P.Fecha_Inicio), V.Precio_Por_Publicar, V.Nombre, U.ID_User
go

create view TG.Estad_Facturacion as
select u.ID_User Usuario,(SUM(F.Total)) as Facturacion,
(case when MONTH(F.Fecha) between 1 and 3 then 1
when MONTH(F.Fecha) between 4 and 6 then 2
when MONTH(F.Fecha) between 7 and 9 then 3
when MONTH(F.Fecha) between 10 and 12 then 4 end) as Trimestre,
YEAR(F.Fecha) as Anio
from TG.Factura F, TG.Usuario u
where F.ID_Vendedor = u.ID_User
group by YEAR(F.Fecha), (case when MONTH(F.Fecha) between 1 and 3 then 1
when MONTH(F.Fecha) between 4 and 6 then 2
when MONTH(F.Fecha) between 7 and 9 then 3
when MONTH(F.Fecha) between 10 and 12 then 4 end), u.ID_User
go

create view TG.Estad_Calificaciones as
select P.ID_Vendedor Usuario, (SUM(C.Calif_Estrellas)/COUNT(*)) as Calificacion,
(case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end) as Trimestre,
YEAR(C.Fecha) as Anio
from TG.Compra C, TG.Publicacion P
where C.ID_Publicacion = P.ID_Publicacion
group by YEAR(C.Fecha), (case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end), P.ID_Vendedor
go

create view TG.Estad_Calificar as
select C.ID_Comprador Usuario, COUNT(*) as Cantidad,
(case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end) as Trimestre,
YEAR(C.Fecha) as Anio
from TG.Compra C
where C.Calif_Estrellas = 0
group by YEAR(C.Fecha), (case when MONTH(C.Fecha) between 1 and 3 then 1
when MONTH(C.Fecha) between 4 and 6 then 2
when MONTH(C.Fecha) between 7 and 9 then 3
when MONTH(C.Fecha) between 10 and 12 then 4 end), C.ID_Comprador
go
