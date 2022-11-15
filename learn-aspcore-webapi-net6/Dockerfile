#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["learn-aspcore-webapi-net6/learn-aspcore-webapi-net6.csproj", "learn-aspcore-webapi-net6/"]
RUN dotnet restore "learn-aspcore-webapi-net6/learn-aspcore-webapi-net6.csproj"
COPY . .
WORKDIR "/src/learn-aspcore-webapi-net6"
RUN dotnet build "learn-aspcore-webapi-net6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "learn-aspcore-webapi-net6.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "learn-aspcore-webapi-net6.dll"]