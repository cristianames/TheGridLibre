--use GD1C2014
--go
create procedure TG.login @user numeric(18,0), @pass nvarchar(255), @protocolo int out as
begin

declare cursorUsuario cursor for (select ID_User,Pass,Inhabilitado,Intentos from TG.Usuario where ID_User = @user)
declare @user_t numeric(18,0)
declare @pass_t nvarchar(255)
declare @inhabilitado bit
declare @intentos int
declare @rowcount int

set @protocolo = 0;

open cursorUsuario;
fetch next from cursorUsuario into @user_t, @pass_t, @Inhabilitado, @Intentos
set @rowcount = @@ROWCOUNT

close cursorUsuario
deallocate cursorUsuario

if @rowcount = 0
begin
	set @protocolo = 1
	print 'Usuario No encontrado'
	return
end

if @Inhabilitado = 1
begin
	set @protocolo = 2
	print 'Usuario Inhabilitado'
	return
end

if @pass <> @pass_t
begin
	if @intentos >= 3
	begin
		set @protocolo = 4
	    update TG.Usuario set Inhabilitado=1 where ID_User=@user --el resto por trigger  :3
		print 'Pass erroneo y usuario Inhabilitado'
		return
	end
	
	else
	
	begin
		set @intentos = @intentos + 1
		set @protocolo = 3
		update TG.Usuario set Intentos = @intentos where ID_User = @user
		print 'Pass erroneo'
		return
	end
end
set @intentos = 1

if (select COUNT(*) from TG.Roles_x_Usuario where ID_User = @user AND Inhabilitado = 0) = 0
begin 
	set @protocolo = 5
end

update TG.Usuario set Intentos = @intentos where ID_User = @user
return

end
go