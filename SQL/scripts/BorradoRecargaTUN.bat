@echo off 
echo Gracias por usar software TheGRID 
echo La migracion comenzara en breve...
ping 127.0.0.1 -n 2 >nul
echo.
echo Migracion
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i droppeo.sql,Limpiado.sql
echo .
echo               Limpieza finalizada         -------   FIN ETAPA 1/8
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i Creacion.sql,Funciones.sql
echo .
echo           Tablas y Funciones Cocinadas    -------   FIN ETAPA 2/8
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i procLogin.sql,triggers.sql
echo .
echo            Login y Triggers terminados    -------   FIN ETAPA 3/8
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i Mig.Cliente-Empresa.sql
echo .
echo            Clientes y Empresas migradas   -------   FIN ETAPA 4/8
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i Mig.Visibilidad-Rubro.sql
echo .
echo          Visibilidades y Rubros migrados  -------   FIN ETAPA 5/8
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i Mig.Publicacion.sql
echo .
echo               Publicaciones migradas      -------   FIN ETAPA 6/8
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i Mig.Factura.sql
echo .
echo                 Facturas emitidas         -------   FIN ETAPA 7/8
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i Mig.Compra.sql,Mig.Oferta.sql
echo .
echo            Compras y Ofertas migradas     -------   FIN ETAPA 8/8
echo Fin de la migracion
echo .
echo .
ping 127.0.0.1 -n 3 >nul
echo IIIII I      III    IIIII IIII  IIIII IIII
ping 127.0.0.1 -n 2 >nul
echo   I   I     I   I   I     I   I   I   I   I
ping 127.0.0.1 -n 2 >nul
echo   I   IIII  IIII    I III IIII    I   I   I
ping 127.0.0.1 -n 2 >nul
echo   I   I   I I       I   I I  I    I   I   I
ping 127.0.0.1 -n 2 >nul
echo   I   I   I  III    IIIII I   I IIIII IIII
ping 127.0.0.1 -n 2 >nul
pause exit[/quote] 