use GD1C2014
go

create trigger TG.inhabilitarUsuario on TG.Usuario for update as
begin

declare usuariosModificados cursor for (select ID_User, Inhabilitado from inserted)
declare @usuario numeric(18,0)
declare @inhabilitado bit

open usuariosModificados
fetch next from usuariosModificados into @usuario, @inhabilitado 

while (@@fetch_status = 0)
begin

update TG.Publicacion set Estado=(CASE when @inhabilitado=1 then 'Pausada' else 'Publicada' end) where ID_Vendedor = @usuario

fetch next from usuariosModificados into @usuario, @inhabilitado
end

close usuariosModificados
deallocate usuariosModificados

end
go

use GD1C2014
go
drop trigger TG.inhabilitarUsuario
go