FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DogClub/DogClub.csproj", "DogClub/"]
RUN dotnet restore "DogClub/DogClub.csproj"
COPY . .
WORKDIR "/src/DogClub"
RUN dotnet build "DogClub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DogClub.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DogClub.dll"]
