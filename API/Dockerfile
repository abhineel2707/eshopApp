FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

#Copy csproj and restore as distinct layer
COPY ["*.sln","."]
COPY ["API/API.csproj", "./API/"]
COPY ["*Core/Core.csproj","./Core/"]
COPY ["*Infrastructure/Infrastructure.csproj","./Infrastructure/"]


RUN dotnet restore

COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
