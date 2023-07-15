FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CarbonNeutral.Identity.Admin.Api/CarbonNeutral.Identity.Admin.Api.csproj", "src/CarbonNeutral.Identity.Admin.Api/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/CarbonNeutral.Identity.Admin.EntityFramework.Shared.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/"]
COPY ["src/CarbonNeutral.Identity.Shared/CarbonNeutral.Identity.Shared.csproj", "src/CarbonNeutral.Identity.Shared/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.MySql/CarbonNeutral.Identity.Admin.EntityFramework.MySql.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/CarbonNeutral.Identity.Admin.Api/CarbonNeutral.Identity.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/CarbonNeutral.Identity.Admin.Api"
RUN dotnet build "CarbonNeutral.Identity.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarbonNeutral.Identity.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "CarbonNeutral.Identity.Admin.Api.dll"]