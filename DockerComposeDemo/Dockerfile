FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY DockerComposeDemo/DockerComposeDemo.csproj DockerComposeDemo/
RUN dotnet restore "DockerComposeDemo/DockerComposeDemo.csproj"
COPY . .
WORKDIR "/src/DockerComposeDemo"
RUN dotnet build "DockerComposeDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerComposeDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerComposeDemo.dll"]
