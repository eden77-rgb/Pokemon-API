FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Install the application dependencies
# 
# Copy everything
# Restore as distinct layers
# Build and publish a release

COPY . ./ 
RUN dotnet restore "src/ServiceRequestApp.Api/ServiceRequestApp.Api.csproj"
RUN dotnet publish "src/ServiceRequestApp.Api/ServiceRequestApp.Api.csproj" -c Release -o /app/out



# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 5000
ENTRYPOINT ["dotnet", "ServiceRequestApp.Api.dll"]