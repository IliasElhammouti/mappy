FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FeedService.Api/FeedService.Api.csproj", "FeedService.Api/"]
RUN dotnet restore "FeedService.Api/FeedService.Api.csproj"
COPY . .
WORKDIR "/src/FeedService.Api"
RUN dotnet build "FeedService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeedService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeedService.Api.dll"]
