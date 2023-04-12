FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NewsKraken.API/", "NewsKraken.API/NewsKraken.API.csproj"]
COPY ["NewsKraken.Core/", "NewsKraken.Core/NewsKraken.Core.csproj"]
COPY ["NewsKraken.Database/", "NewsKraken.Database/NewsKraken.Database.csproj"]
RUN dotnet restore "NewsKraken.API/NewsKraken.API.csproj"
COPY . .
WORKDIR "/src/NewsKraken.API"
RUN dotnet build "NewsKraken.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewsKraken.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsKraken.API.dll"]
