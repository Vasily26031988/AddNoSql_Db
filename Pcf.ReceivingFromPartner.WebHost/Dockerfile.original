FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pcf.ReceivingFromPartner.WebHost/Pcf.ReceivingFromPartner.WebHost.csproj", "Pcf.ReceivingFromPartner.WebHost/"]
RUN dotnet restore "Pcf.ReceivingFromPartner.WebHost/Pcf.ReceivingFromPartner.WebHost.csproj"
COPY . .
WORKDIR "/src/Pcf.ReceivingFromPartner.WebHost"
RUN dotnet build "Pcf.ReceivingFromPartner.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pcf.ReceivingFromPartner.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pcf.ReceivingFromPartner.WebHost.dll"]
