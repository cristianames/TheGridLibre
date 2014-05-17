insert into GD1C2014.TG.Oferta 

select C.ID_User, X.Publicacion_Cod, Concretada= case when C.ID_User = CO.ID_Comprador then 1 else 0 end , X.Oferta_Fecha, X.Oferta_Monto
from  GD1C2014.TG.Compra CO,GD1C2014.TG.Cliente C , (select Cli_Dni, Publicacion_Cod,Oferta_Fecha, Oferta_Monto from GD1C2014.gd_esquema.Maestra where Oferta_Fecha is not null) X
where C.Documento = X.Cli_Dni