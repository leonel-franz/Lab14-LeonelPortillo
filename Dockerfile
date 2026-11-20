FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Lab08-LeonelPortillo/Lab08-LeonelPortillo.csproj", "Lab08-LeonelPortillo/"]
RUN dotnet restore "Lab08-LeonelPortillo/Lab08-LeonelPortillo.csproj"

COPY . .
WORKDIR /src/Lab08-LeonelPortillo

RUN dotnet publish "Lab08-LeonelPortillo.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 10000

ENTRYPOINT ["dotnet", "Lab08-LeonelPortillo.dll"]