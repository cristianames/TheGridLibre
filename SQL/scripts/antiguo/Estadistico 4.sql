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