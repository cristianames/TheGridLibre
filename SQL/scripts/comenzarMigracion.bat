@echo off 
echo Gracias por usar software TheGRID 
echo La migracion comenzara en breve...
ping 127.0.0.1 -n 2 >nul
echo.
echo Migracion
sqlcmd -S localhost\SQLSERVER2008 -U gd -P gd2014 -i script_creacion_inicial.sql
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