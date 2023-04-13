FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "NewsKraken.API/NewsKraken.API.csproj"
WORKDIR "/src/NewsKraken.API"
RUN dotnet build "NewsKraken.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewsKraken.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsKraken.API.dll"]
