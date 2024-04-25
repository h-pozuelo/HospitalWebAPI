# La instrucción FROM inicia la fase de compilación estableciendo como imagen base
# para las siguientes instrucciones
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# La instrucción WORKDIR establece el área de trabajo para las siguientes instrucciones
WORKDIR /app
# La instrucción EXPOSE hace que el contenedor escuche por el puerto especificado
EXPOSE 80
EXPOSE 443

# Para poder incluir aplicaciones ASP.NET Core en el contenedor debemos establecer
# como imagen base el SDK de .NET. Nombramos a la fase de compilación como "build"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# La instrucción COPY copia ficheros/directorios desde la ruta en la que se encuentra el
# fichero "Dockerfile" hacia el área de trabajo establecido ("/src")
COPY *.csproj ./
# La instrucción "RUN dotnet restore" crea una imagen sobre "build" con aquellas dependencias
# necesarias (paquetes NuGet) para poder compilar
RUN dotnet restore
# Despues de restaurar las dependencias necesarias debemos copiar todos los ficheros/directorios
# a la imagen correspondiente
COPY . ./
# Para crear una imagen desplegable debemos de ejecutar el comando "dotnet publish". Pero antes...
WORKDIR /src/.
# Para construir la aplicación ejecutamos el comando "dotnet build" sobre la imagen :
#	- "-c" : Determina el tipo de configuración (Ej. Release).
#	- "-o" : Directorio de salida en donde copiar los binarios.
RUN dotnet build -c Release -o /app/build

# Para publicar la aplicación iniciamos una fase de compilación estableciendo como imagen base
# la anterior fase de compilación ("build")
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Para ejecutar el contenedor iniciamos una fase de compilación estableciendo como imagen base
# la fase de compilación "base" ("mcr.microsoft.com/dotnet/aspnet:8.0")
FROM base AS final
# Cambiamos el área de trabajo de "/src/." a "/app"
WORKDIR /app
# Copiamos desde la fase de compilación "publish" los ficheros/directiorios de la ruta "/app/publish"
# hacia la fase de compilación "final" en el área de trabajo en el que nos encontramos
COPY --from=publish /app/publish .
# La instrucción ENTRYPOINT permite configurar un contenedor ejecutable :
#	- [0] : Ejecutable/compilador (Ej. dotnet).
#	- [1] : Fichero ".dll" de la aplicación.
ENTRYPOINT ["dotnet", "Hospital.dll"]