FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CommunityService.Api/CommunityService.Api.csproj", "CommunityService.Api/"]
RUN dotnet restore "CommunityService.Api/CommunityService.Api.csproj"
COPY . .
WORKDIR "/src/CommunityService.Api"
RUN dotnet build "CommunityService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommunityService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommunityService.Api.dll"]
