# ----------------------
# Stage 1: Build
# ----------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy all projects into the container (API + Data)
COPY . .

# Restore dependencies for API project (MSBuild will resolve Data reference)
RUN dotnet restore AzureDemoApi/AzureDemoApi.csproj

# Publish API project
RUN dotnet publish AzureDemoApi/AzureDemoApi.csproj -c Release -o /app

# ----------------------
# Stage 2: Runtime
# ----------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app .

# Run API
ENTRYPOINT ["dotnet", "AzureDemoApi.dll"]