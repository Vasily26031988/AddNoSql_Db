FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Pcf.GivingToCustomer.WebHost/Pcf.GivingToCustomer.WebHost.csproj", "Pcf.GivingToCustomer.WebHost/"]
COPY ["Pcf.GivingToCustomer.Core/Pcf.GivingToCustomer.Core.csproj", "Pcf.GivingToCustomer.Core/"]
COPY ["Pcf.GivingToCustomer.DataAccess/Pcf.GivingToCustomer.DataAccess.csproj", "Pcf.GivingToCustomer.DataAccess/"]
COPY ["Pcf.GivingToCustomer.IntegrationTests/Pcf.GivingToCustomer.IntegrationTests.csproj", "Pcf.GivingToCustomer.IntegrationTests/"]
COPY ["Pcf.GivingToCustomer.Integration/Pcf.GivingToCustomer.Integration.csproj", "Pcf.GivingToCustomer.Integration/"]
RUN dotnet restore "Pcf.GivingToCustomer.WebHost/Pcf.GivingToCustomer.WebHost.csproj"
COPY . .
WORKDIR "/src/Pcf.GivingToCustomer.WebHost"
RUN dotnet build "Pcf.GivingToCustomer.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pcf.GivingToCustomer.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pcf.GivingToCustomer.WebHost.dll"]
