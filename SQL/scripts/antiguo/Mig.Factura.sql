insert into TG.Factura 

select Factura_Nro, TG.dameUserIDdni(Publ_Cli_Dni), Factura_Fecha, Forma_Pago_Desc, 0, Factura_Total
from gd_esquema.Maestra
where Publ_Cli_Dni is not null
group by Factura_Nro, Publ_Cli_Dni, Factura_Fecha, Forma_Pago_Desc, Factura_Total
having Factura_Nro is not null 

union

select Factura_Nro, TG.dameUserIDcuit(Publ_Empresa_Cuit), Factura_Fecha, Forma_Pago_Desc, 0, Factura_Total
from gd_esquema.Maestra
where Publ_Empresa_Cuit is not null
group by Factura_Nro, Publ_Empresa_Cuit, Factura_Fecha, Forma_Pago_Desc, Factura_Total
having Factura_Nro is not null 

order by Factura_Nro

insert into TG.RenglonFactura
select Factura_Nro, Publicacion_Cod, Item_Factura_Monto, Item_Factura_Cantidad 
from gd_esquema.Maestra where Factura_Nro is not null order by Factura_Nro