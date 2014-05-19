USE [GD1C2014]
GO

if not exists(select * from sys.schemas where name = 'TG')
execute('CREATE SCHEMA [TG] AUTHORIZATION [gd]')

else print('No te creo nada')
GO