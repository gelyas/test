#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestDocker_/TestDocker_.csproj", "TestDocker_/"]
RUN dotnet restore "TestDocker_/TestDocker_.csproj"
COPY . .
WORKDIR "/src/TestDocker_"
RUN dotnet build "TestDocker_.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestDocker_.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDocker_.dll"]