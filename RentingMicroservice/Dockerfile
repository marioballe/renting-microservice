FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 7169
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RentingMicroservice/RentingMicroservice.Api.csproj", "RentingMicroservice/"]
RUN dotnet restore "./RentingMicroservice/RentingMicroservice.Api.csproj"
COPY . .
WORKDIR "/src/RentingMicroservice"
RUN dotnet build "./RentingMicroservice.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RentingMicroservice.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentingMicroservice.Api.dll"]
