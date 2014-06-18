use GD1C2014
go

create trigger TG.inhabilitarVisibilidad on TG.Visibilidad for update as
begin

declare visibilidadesModificadas cursor for (select ID_Visibilidad, Inhabilitado from inserted)
declare @visibilidad numeric(18,0)
declare @inhabilitado bit

open visibilidadesModificadas
fetch next from visibilidadesModificadas into @visibilidad, @inhabilitado 

while (@@fetch_status = 0)
begin

update TG.Publicacion set Estado=(CASE when @inhabilitado=1 then 'Pausada' else 'Publicada' end) where ID_Visibilidad = @visibilidad

fetch next from visibilidadesModificadas into @visibilidad, @inhabilitado
end

close visibilidadesModificadas
deallocate visibilidadesModificadas

end
go

use GD1C2014
go
drop trigger TG.inhabilitarVisibilidad
go
