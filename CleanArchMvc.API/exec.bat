@echo off
set PROJECT_NAME=D:\repos\CleanArchMvc\CleanArchMvc.API
set DOTNET_PATH=C:\Program Files\dotnet\dotnet.exe

echo Iniciando a API %PROJECT_NAME%...

REM Navega para o diretório do projeto, se necessário (remova se o .bat já estiver no diretório raiz)
REM cd C:\Caminho\Para\Seu\Projeto\Api

"%DOTNET_PATH%" watch run --project %PROJECT_NAME%.csproj 

echo.
echo A API foi encerrada.
pause