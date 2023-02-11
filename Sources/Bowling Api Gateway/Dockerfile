FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sources/Bowling Api Gateway/Bowling Api Gateway.csproj", "Bowling Api Gateway/"]
RUN dotnet restore "Bowling Api Gateway/Bowling Api Gateway.csproj"
COPY . .
WORKDIR "/src/Bowling Api Gateway"
RUN dotnet build "Bowling Api Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bowling Api Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bowling Api Gateway.dll"]
