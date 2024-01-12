#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Asignment6/Asignment6.csproj", "Asignment6/"]
RUN dotnet restore "Asignment6/Asignment6.csproj"
COPY . .
WORKDIR "/src/Asignment6"
RUN dotnet build "Asignment6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asignment6.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asignment6.dll"]