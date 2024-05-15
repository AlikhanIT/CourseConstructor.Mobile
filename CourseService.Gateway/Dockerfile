FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CourseService.Gateway/CourseService.Gateway.csproj", "CourseService.Gateway/"]
RUN dotnet restore "CourseService.Gateway/CourseService.Gateway.csproj"
COPY . .
WORKDIR "/src/CourseService.Gateway"
RUN dotnet build "CourseService.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseService.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseService.Gateway.dll"]
