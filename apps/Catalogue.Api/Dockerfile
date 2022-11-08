﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["apps/Catalogue.Api/Catalogue.Api.csproj", "Catalogue.Api/"]
RUN dotnet restore "apps/Catalogue.Api/Catalogue.Api.csproj"
COPY . .
WORKDIR "/src/Catalogue.Api"
RUN dotnet build "Catalogue.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalogue.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalogue.Api.dll"]