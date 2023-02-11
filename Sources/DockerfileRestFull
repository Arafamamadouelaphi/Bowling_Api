FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sources/BowlingApi/BowlingApi.csproj", "BowlingApi/"]
COPY ["Sources/BowlingService/BowlingService.csproj", "BowlingService/"]
COPY ["Sources/BowlingLib/BowlingLib.csproj", "BowlingLib/"]
COPY ["Sources/BowlingRepository/BowlingRepository.csproj", "BowlingRepository/"]
COPY ["Sources/BowlingEF/BowlingEF.csproj", "BowlingEF/"]
COPY ["Sources/DTOs/DTOs.csproj", "DTOs/"]
COPY ["Sources/Mapper/Mapper.csproj", "Mapper/"]
RUN dotnet restore "BowlingApi/BowlingApi.csproj"
COPY . .
WORKDIR "/src/BowlingApi"
RUN dotnet build "BowlingApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BowlingApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BowlingApi.dll"]
