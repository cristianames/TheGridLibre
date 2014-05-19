use GD1C2014
go
create function TG.dameUserIDdni (@dni numeric(18,0)) returns numeric(18,0) as
begin
	return (select c.ID_User from TG.Cliente c where @dni = c.Documento )
end
go

use GD1C2014
go
create function TG.dameUserIDcuit (@cuit nvarchar(50)) returns numeric(18,0) as
begin
	return (select e.ID_User from TG.Empresa e where @cuit = e.CUIT )
end
go

use GD1C2014
go

create function TG.dameIDFactura (@Publicacion numeric(18,0)) returns numeric(18,0) as
begin

return (select ID_Factura from TG.Factura where ID_Publicacion = @Publicacion)

end

go