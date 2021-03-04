# MVCPrototipo
MVCPrototipo

## Crear un nuevo solucionado MVC
- dotnet new mvc

## luego instala tool
- dotnet tool install --global dotnet-aspnet-codegenerator --version 3.1.2

## luego las Libreria 
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design

## para que se puedan implementar las librerías.
- dotnet restore

## crear pagina asp.net y controller

dotnet aspnet-codegenerator controller -name InstructorController -m Instructor -dc ContextoCursos --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
