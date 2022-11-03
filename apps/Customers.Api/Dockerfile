FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["apps/Customers.Api/Customers.Api.csproj", "apps/Customers.Api/Customers.Api.csproj"]
COPY ["src/Customers/Customers.csproj", "src/Customers/Customers.csproj"]
COPY ["src/Shared/Shared.csproj", "src/Shared/Shared.csproj"]

RUN dotnet restore "apps/Customers.Api/Customers.Api.csproj"

COPY . .
WORKDIR "/src/apps/Customers.Api"
RUN dotnet build "Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dew.Customers.Api.dll"]
