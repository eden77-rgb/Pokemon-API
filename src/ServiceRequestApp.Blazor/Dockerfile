FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Install the application dependencies
# 
# Copy everything
# Restore as distinct layers
# Build and publish a release

COPY . ./ 
RUN dotnet publish "src/ServiceRequestApp.Blazor/ServiceRequestApp.Blazor.csproj" -c Release -o /app/out



# Build runtime image
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build /app/out/wwwroot .

EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]
