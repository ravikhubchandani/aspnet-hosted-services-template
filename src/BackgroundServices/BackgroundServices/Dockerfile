#docker build -t background-services:1.0 . 
#docker container run --name background-jobs-server -p 5000:80 background-services:1.0

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY BackgroundServices.csproj .
RUN dotnet restore "BackgroundServices.csproj"
COPY . .
RUN dotnet build "BackgroundServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackgroundServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackgroundServices.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet BackgroundServices.dll