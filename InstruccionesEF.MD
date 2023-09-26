# Instalacion EntityFramework

desde el CLI -> (Toll-> CommandLine -> command prompt for developers)
sobre la carpeta del proyecto

# Pasos para instalar
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design

#pasos para crear y actualizar la base de datos y sus objetos

dotnet ef migrations add InitialCreate
dotnet ef database update