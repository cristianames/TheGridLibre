--use GD1C2014
--go

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

--use GD1C2014
--go

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