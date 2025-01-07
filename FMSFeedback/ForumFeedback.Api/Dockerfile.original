# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# COPY csproj files from other projects into their respective directories
COPY ["ForumFeedback.Application/ForumFeedback.Application.csproj", "ForumFeedback.Application/"]
COPY ["ForumFeedback.Domain/ForumFeedback.Domain.csproj", "ForumFeedback.Domain/"]
COPY ["ForumFeedback.Infrastructure/ForumFeedback.Infrastructure.csproj", "ForumFeedback.Infrastructure/"]
COPY ["ForumFeedback.DatabaseMigration/ForumFeedback.DatabaseMigration.csproj", "ForumFeedback.DatabaseMigration/"]
COPY ["ForumFeedback.Api/ForumFeedback.Api.csproj", "ForumFeedback.Api/"]

RUN dotnet restore "./ForumFeedback.Api/ForumFeedback.Api.csproj"
COPY . .
WORKDIR "/src/ForumFeedback.Api"
RUN dotnet build "./ForumFeedback.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ForumFeedback.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ForumFeedback.Api.dll"]