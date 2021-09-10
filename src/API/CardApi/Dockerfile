#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/API/CardApi/CardApi.csproj", "src/API/CardApi/"]
RUN dotnet restore "src/API/CardApi/CardApi.csproj"
COPY . .
WORKDIR "/src/src/API/CardApi"
RUN dotnet build "CardApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardApi.dll"]