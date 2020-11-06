#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Beringela.Api/Beringela.Api.csproj", "Beringela.Api/"]
RUN dotnet restore "Beringela.Api/Beringela.Api.csproj"
COPY . .
WORKDIR "/src/Beringela.Api"
RUN dotnet build "Beringela.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Beringela.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Beringela.Api.dll"]