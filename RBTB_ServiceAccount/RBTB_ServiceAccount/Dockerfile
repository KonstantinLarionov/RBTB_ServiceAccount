FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RBTB_ServiceAccount/RBTB_ServiceAccount.csproj", "RBTB_ServiceAccount/"]
RUN dotnet restore "RBTB_ServiceAccount/RBTB_ServiceAccount.csproj"
COPY . .
WORKDIR "/src/RBTB_ServiceAccount"
RUN dotnet build "RBTB_ServiceAccount.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RBTB_ServiceAccount.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RBTB_ServiceAccount.dll"]
