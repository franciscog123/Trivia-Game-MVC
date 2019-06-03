FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TriviaGameMVC.WebApp/TriviaGameMVC.WebApp.csproj", "TriviaGameMVC.WebApp/"]
RUN dotnet restore "TriviaGameMVC.WebApp/TriviaGameMVC.WebApp.csproj"
COPY . .
WORKDIR "/src/TriviaGameMVC.WebApp"
RUN dotnet build "TriviaGameMVC.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TriviaGameMVC.WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TriviaGameMVC.WebApp.dll"]