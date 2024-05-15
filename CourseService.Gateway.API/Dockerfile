FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CourseService.Gateway.API/CourseService.Gateway.API.csproj", "CourseService.Gateway.API/"]
RUN dotnet restore "CourseService.Gateway.API/CourseService.Gateway.API.csproj"
COPY . .
WORKDIR "/src/CourseService.Gateway.API"
RUN dotnet build "CourseService.Gateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseService.Gateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseService.Gateway.API.dll"]
