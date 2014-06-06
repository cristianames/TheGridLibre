use GD1C2014
go

create trigger TG.inhabilitarRoles on TG.Rol for update as
begin

declare rolesModificados cursor for (select ID_Rol, Inhabilitado from inserted)
declare @ID_Rol numeric(18,0)
declare @Inhabilitado bit

open rolesModificados
fetch next from rolesModificados into @ID_Rol, @Inhabilitado 

while (@@fetch_status = 0)
begin

update TG.Roles_X_Usuario set Inhabilitado = @Inhabilitado where ID_Rol = @ID_Rol

fetch next from rolesModificados into @ID_Rol, @Inhabilitado
end

close rolesModificados
deallocate rolesModificados

end
go

use GD1C2014
go
drop trigger TG.inhabilitarRoles
go