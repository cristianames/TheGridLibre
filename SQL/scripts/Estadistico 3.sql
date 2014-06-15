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