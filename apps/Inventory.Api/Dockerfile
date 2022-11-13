FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["apps/Inventory.Api/Inventory.Api.csproj", "apps/Inventory.Api/Inventory.Api.csproj"]
COPY ["src/Inventory/Inventory.csproj", "src/Inventory/Inventory.csproj"]
COPY ["src/Shared/Shared.csproj", "src/Shared/Shared.csproj"]

RUN dotnet restore "apps/Inventory.Api/Inventory.Api.csproj"

COPY . .
WORKDIR "/src/apps/Inventory.Api"
RUN dotnet build "Inventory.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dew.Inventory.Api.dll"]
