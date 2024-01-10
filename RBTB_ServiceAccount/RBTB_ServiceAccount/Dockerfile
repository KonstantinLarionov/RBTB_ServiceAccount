#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RBTB_ServiceAccount/RBTB_ServiceAccount.csproj", "RBTB_ServiceAccount/"]
COPY ["RBTB_ServiceAccount.API/RBTB_ServiceAccount.API.csproj", "RBTB_ServiceAccount.API/"]
COPY ["RBTB_ServiceAccount.Application/RBTB_ServiceAccount.Application.csproj", "RBTB_ServiceAccount.Application/"]
COPY ["RBTB_ServiceAccount.Database/RBTB_ServiceAccount.Database.csproj", "RBTB_ServiceAccount.Database/"]
RUN dotnet restore "./RBTB_ServiceAccount/./RBTB_ServiceAccount.csproj"
COPY . .
WORKDIR "/src/RBTB_ServiceAccount"
RUN dotnet build "./RBTB_ServiceAccount.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RBTB_ServiceAccount.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RBTB_ServiceAccount.dll"]