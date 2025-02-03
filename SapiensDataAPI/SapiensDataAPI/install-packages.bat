@echo off
echo ==========================================
echo Installing required NuGet packages...
echo ==========================================
echo.

REM Ensure script is running with Administrator privileges
NET SESSION >nul 2>&1
IF %ERRORLEVEL% NEQ 0 (
    echo Please run this script as Administrator!
    pause
    exit /b
)

REM Navigate to the project directory (adjust if needed)
cd /d "%~dp0"

REM Install packages (latest version)
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Swashbuckle.AspNetCore
dotnet add package DotNetEnv
dotnet add package Microsoft.AspNetCore.Cors
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package AutoMapper
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet restore

echo.
echo All packages have been installed successfully!
pause
exit
