FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["apps/Shops.Api/Shops.Api.csproj", "apps/Shops.Api/Shops.Api.csproj"]
COPY ["src/Shops/Shops.csproj", "src/Shops/Shops.csproj"]
COPY ["src/Shared/Shared.csproj", "src/Shared/Shared.csproj"]

RUN dotnet restore "apps/Shops.Api/Shops.Api.csproj"

COPY . .
WORKDIR "/src/apps/Shops.Api"
RUN dotnet build "Shops.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shops.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dew.Shops.Api.dll"]
