FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["apps/Invoices.Api/Invoices.Api.csproj", "apps/Invoices.Api/Invoices.Api.csproj"]
COPY ["src/Invoices/Invoice.csproj", "src/Invoices/Invoice.csproj"]
COPY ["src/Shared/Shared.csproj", "src/Shared/Shared.csproj"]

RUN dotnet restore "apps/Invoices.Api/Invoices.Api.csproj"

COPY . .
WORKDIR "/src/apps/Invoices.Api"
RUN dotnet build "Invoices.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Invoices.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dew.Invoices.Api.dll"]
