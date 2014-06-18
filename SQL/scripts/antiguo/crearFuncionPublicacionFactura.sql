use GD1C2014
go

create function TG.dameIDFactura (@Publicacion numeric(18,0)) returns numeric(18,0) as
begin

return (select distinct Factura_Nro from gd_esquema.Maestra where Publicacion_Cod = @Publicacion and Factura_Nro is not Null)

end

go