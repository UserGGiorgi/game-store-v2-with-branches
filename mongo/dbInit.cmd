@ECHO OFF

ECHO Local Northwind db init

SETLOCAL ENABLEDELAYEDEXPANSION

FOR /r data %%i IN (*.csv) DO (
	ECHO Importing %%~ni...
	"mongobin/mongoimport.exe" -d Northwind --collection %%~ni --type csv --file %%~fi --headerline --drop
	ECHO Importing %%~ni done
)
ENDLOCAL

ECHO Done!