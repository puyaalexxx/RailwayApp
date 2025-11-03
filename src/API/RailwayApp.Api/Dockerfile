FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/RailwayApp.Api/RailwayApp.Api.csproj", "src/API/RailwayApp.Api/"]
RUN dotnet restore "src/API/RailwayApp.Api/RailwayApp.Api.csproj"
COPY . .
WORKDIR "/src/src/API/RailwayApp.Api"
RUN dotnet build "./RailwayApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RailwayApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RailwayApp.Api.dll"]
