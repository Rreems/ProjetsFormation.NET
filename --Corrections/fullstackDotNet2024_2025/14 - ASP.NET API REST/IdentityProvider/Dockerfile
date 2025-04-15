# Utiliser l'image de base officielle .NET 8 pour les applications
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Utiliser l'image de base officielle .NET SDK pour le build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier le fichier .csproj et restaurer les dépendances
COPY ["IdentityProvider.csproj", "./"]
RUN dotnet restore "./IdentityProvider.csproj"

# Copier le reste des fichiers de l'application et compiler
COPY . .
WORKDIR "/src"
RUN dotnet build "IdentityProvider.csproj" -c Release -o /app/build

# Publier l'application
FROM build AS publish
RUN dotnet publish "IdentityProvider.csproj" -c Release -o /app/publish

# Étape finale - utiliser l'image de base pour exécuter l'application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityProvider.dll"]

