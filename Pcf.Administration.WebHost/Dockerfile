FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Pcf.Administration.WebHost/Pcf.Administration.WebHost.csproj", "Pcf.Administration.WebHost/"]
COPY ["Pcf.Administration.Core/Pcf.Administration.Core.csproj", "Pcf.Administration.Core/"]
COPY ["Pcf.Administration.DataAccess/Pcf.Administration.DataAccess.csproj", "Pcf.Administration.DataAccess/"]
COPY ["Pcf.Administration.IntegrationTests/Pcf.Administration.IntegrationTests.csproj", "Pcf.Administration.IntegrationTests/"]
RUN dotnet restore "Pcf.Administration.WebHost/Pcf.Administration.WebHost.csproj"
COPY . .
WORKDIR "/src/Pcf.Administration.WebHost"
RUN dotnet build "Pcf.Administration.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pcf.Administration.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pcf.Administration.WebHost.dll"]
