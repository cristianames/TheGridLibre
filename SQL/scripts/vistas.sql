create view TG.VendedoresConMasArticulosNoVendidos as
select P.ID_Vendedor Usuario,(SUM(P.Stock)) as Cantidad, V.Nombre Visibilidad, V.ID_Visibilidad, 
MONTH(P.Fecha_Inicio) as Mes,
(case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end) as Trimestre,
YEAR(P.Fecha_Inicio) as Anio
from TG.Usuario U, TG.Publicacion P, TG.Visibilidad V
where P.ID_Vendedor = U.ID_User and P.ID_Visibilidad = V.ID_Visibilidad
group by YEAR(P.Fecha_Inicio), MONTH(P.Fecha_Inicio), V.ID_Visibilidad,V.Nombre, P.ID_Vendedor
--order by YEAR(P.Fecha_Inicio), MONTH(P.Fecha_Inicio), V.ID_Visibilidad,SUM(P.Stock)desc, V.Nombre
go

create view TG.VendedoresConMayorFacturacion as
select P.ID_Vendedor Usuario,(SUM(F.Total)) as Facturacion,
(case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end) as Trimestre,
YEAR(P.Fecha_Inicio) as Anio
from TG.Factura F, TG.Publicacion P
where F.ID_Publicacion = P.ID_Publicacion
group by YEAR(P.Fecha_Inicio), (case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end), P.ID_Vendedor
--order by YEAR(P.Fecha_Inicio),(case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
--when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
--when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
--when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end), SUM(F.Total) desc
go

create view TG.VendedoresConMayoresCalificaciones as 
select P.ID_Vendedor, (SUM(C.Calif_Estrellas)/COUNT(*)) as Calificacion,
(case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end) as Trimestre,
YEAR(P.Fecha_Inicio) as Anio
from TG.Compra C, TG.Publicacion P
where C.ID_Publicacion = P.ID_Publicacion
group by YEAR(P.Fecha_Inicio), (case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end), P.ID_Vendedor
--order by YEAR(P.Fecha_Inicio), (case when MONTH(P.Fecha_Inicio) between 1 and 3 then 1
--when MONTH(P.Fecha_Inicio) between 4 and 6 then 2
--when MONTH(P.Fecha_Inicio) between 7 and 9 then 3
--when MONTH(P.Fecha_Inicio) between 10 and 12 then 4 end),(SUM(C.Calif_Estrellas)/COUNT(*)) desc
go