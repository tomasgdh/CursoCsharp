# Instalacion EntityFramework

desde el CLI -> (Toll-> CommandLine -> command prompt for developers)
sobre la carpeta del proyecto

# Pasos para instalar
1. dotnet tool install --global dotnet-ef
2. dotnet add package Microsoft.EntityFrameworkCore
3. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
4. dotnet add package Microsoft.EntityFrameworkCore.Design

#pasos para crear y actualizar la base de datos y sus objetos

1. dotnet ef migrations add InitialCreate
2. dotnet ef database update
