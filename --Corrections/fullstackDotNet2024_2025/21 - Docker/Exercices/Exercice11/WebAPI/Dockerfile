FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY WebAPI.csproj ./

RUN dotnet restore WebAPI.csproj

COPY . .

RUN dotnet build -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS deploy

WORKDIR /app

COPY --from=build /src/out .

EXPOSE 8080 8081

CMD ["dotnet", "WebAPI.dll"]