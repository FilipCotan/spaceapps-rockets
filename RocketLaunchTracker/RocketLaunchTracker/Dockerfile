FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50201
EXPOSE 44373

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["RocketLaunchTracker/RocketLaunchTracker.csproj", "RocketLaunchTracker/"]
RUN dotnet restore "RocketLaunchTracker/RocketLaunchTracker.csproj"
COPY . .
WORKDIR "/src/RocketLaunchTracker"
RUN dotnet build "RocketLaunchTracker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RocketLaunchTracker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RocketLaunchTracker.dll"]