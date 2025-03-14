# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar archivos del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore --disable-parallel

# Copiar el resto del código y compilar la app
COPY . . 
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copiar el resultado compilado desde la etapa anterior
COPY --from=build /app/out .

# Exponer el puerto (puedes cambiarlo según tu API)
EXPOSE 80

# Comando para ejecutar la aplicación de forma dinámica
CMD ["sh", "-c", "dotnet $(ls *.dll | head -n 1)"]

