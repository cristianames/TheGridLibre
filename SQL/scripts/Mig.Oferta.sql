insert into GD1C2014.TG.Oferta 

select 
C.ID_User, X.Publicacion_Cod, case when c.ID_User = CO.ID_Comprador then 1 else 0 end, 
X.Oferta_Fecha, X.Oferta_Monto

from  
gd_esquema.Maestra X
inner join TG.Cliente c ON X.Cli_Dni = c.Documento
inner join TG.Compra CO ON X.Publicacion_Cod = CO.ID_Publicacion

where 
X.Oferta_Fecha is not null