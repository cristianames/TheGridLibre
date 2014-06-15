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