# ---------- BASE RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

# certificados para HTTPS
RUN apt-get update \
    && apt-get install -y ca-certificates \
    && update-ca-certificates


# ---------- BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copiar solo csproj para cache de dependencias
COPY ["API/API.csproj", "API/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# restaurar dependencias
RUN dotnet restore "API/API.csproj"

# copiar el resto del código
COPY . .

WORKDIR /src/API

# publicar aplicación
RUN dotnet publish "API.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


# ---------- FINAL IMAGE ----------
FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "API.dll"]
