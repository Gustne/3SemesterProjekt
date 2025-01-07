# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Login.Api/Login.Api.csproj", "Login.Api/"]
COPY ["Login.Application/Login.Application.csproj", "Login.Application/"]
COPY ["Login.Domain/Login.Domain.csproj", "Login.Domain/"]
COPY ["Login.Infrastructure/Login.Infrastructure.csproj", "Login.Infrastructure/"]
COPY ["Login.DatabaseMigration/Login.DatabaseMigration.csproj", "Login.DatabaseMigration/"]
RUN dotnet restore "./Login.Api/Login.Api.csproj"
COPY . .
WORKDIR "/src/Login.Api"
RUN dotnet build "./Login.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Login.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Login.Api.dll"]