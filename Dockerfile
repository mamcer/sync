# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and restore as distinct layers
COPY ./*.sln ./
COPY src/Nostalgia.Core/*.csproj ./src/Nostalgia.Core/
COPY src/Nostalgia.Data/*.csproj ./src/Nostalgia.Data/
COPY src/Nostalgia.Application/*.csproj ./src/Nostalgia.Application/
COPY src/Nostalgia.Sync/*.csproj ./src/Nostalgia.Sync/
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish src/Nostalgia.Sync/Nostalgia.Sync.csproj -c Release -o /app/publish

# Use the official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set the entrypoint
ENTRYPOINT ["dotnet", "Nostalgia.Sync.dll"]
