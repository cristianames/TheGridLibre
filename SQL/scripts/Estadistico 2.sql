create view TG.Estad_Facturacion as
select P.ID_Vendedor Usuario,(SUM(F.Total)) as Facturacion,
(case when MONTH(F.Fecha) between 1 and 3 then 1
when MONTH(F.Fecha) between 4 and 6 then 2
when MONTH(F.Fecha) between 7 and 9 then 3
when MONTH(F.Fecha) between 10 and 12 then 4 end) as Trimestre,
YEAR(F.Fecha) as Anio
from TG.Factura F, TG.Publicacion P
where F.ID_Publicacion = P.ID_Publicacion
group by YEAR(F.Fecha), (case when MONTH(F.Fecha) between 1 and 3 then 1
when MONTH(F.Fecha) between 4 and 6 then 2
when MONTH(F.Fecha) between 7 and 9 then 3
when MONTH(F.Fecha) between 10 and 12 then 4 end), P.ID_Vendedor
go