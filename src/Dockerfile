FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /app
EXPOSE 80

COPY . ./
# RUN dotnet restore "testing/testing.csproj" -s https://nuget.pricegrabber.xyz/v3/index.json -s https://api.nuget.org/v3/index.json

RUN dotnet publish "testing/testing.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "testing.dll"]