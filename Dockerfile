FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Paperless-Empire.csproj", "."]
RUN dotnet restore "./Paperless-Empire.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Paperless-Empire.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paperless-Empire.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paperless-Empire.dll"]