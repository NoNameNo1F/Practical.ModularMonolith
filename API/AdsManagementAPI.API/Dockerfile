FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/AdsManagementAPI.API/AdsManagementAPI.API.csproj", "API/AdsManagementAPI.API/"]
RUN dotnet restore "API/AdsManagementAPI.API/AdsManagementAPI.API.csproj"
COPY . .
WORKDIR "/src/API/AdsManagementAPI.API"
RUN dotnet build "AdsManagementAPI.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AdsManagementAPI.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdsManagementAPI.API.dll"]
