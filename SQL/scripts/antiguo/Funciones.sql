create function TG.dameUserIDdni (@dni numeric(18,0)) returns numeric(18,0) as
begin
	return (select c.ID_User from TG.Cliente c where @dni = c.Documento )
end
GO

create function TG.dameUserIDcuit (@cuit nvarchar(50)) returns numeric(18,0) as
begin
	return (select e.ID_User from TG.Empresa e where @cuit = e.CUIT )
end
GO
