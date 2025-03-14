# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos y restaurar dependencias
COPY . .
RUN dotnet restore

# Compilar la aplicación
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar solo la salida compilada
COPY --from=build /app/out .

# Exponer el puerto (si aplica)
EXPOSE 80

# Ejecutar la API
ENTRYPOINT ["dotnet", "ApiSiniestrosAxa.Core.dll"]
