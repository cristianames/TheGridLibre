insert into TG.Factura 
select distinct Factura_Nro, Factura_Fecha, Forma_Pago_Desc, C.Nro_Tarjeta, Factura_Total
from gd_esquema.Maestra, TG.Cliente C
where Factura_Nro is not null