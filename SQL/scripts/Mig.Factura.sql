insert into GD1C2014.TG.Factura 
select Factura_Nro, Publicacion_Cod, Factura_Fecha, Forma_Pago_Desc, NULL, Factura_Total
from gd_esquema.Maestra
group by Factura_Nro, Publicacion_Cod, Factura_Fecha, Forma_Pago_Desc, Factura_Total
having Factura_Nro is not null