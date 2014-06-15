<<<<<<< HEAD
--use GD1C2014
--go
insert into TG.Oferta 

select 
C.ID_User, X.Publicacion_Cod, case when c.ID_User = CO.ID_Comprador then 1 else 0 end,
X.Oferta_Fecha, X.Oferta_Monto

from  
gd_esquema.Maestra X
inner join TG.Cliente c ON X.Cli_Dni = c.Documento
inner join TG.Compra CO ON X.Publicacion_Cod = CO.ID_Publicacion

where 
X.Oferta_Fecha is not null
order by X.Oferta_Fecha
=======
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
order by X.Oferta_Fecha

GO
>>>>>>> e4fc2f28f28b612e1cb42414d1677e0937f5024a
