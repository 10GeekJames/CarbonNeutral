FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 44302
EXPOSE 44303
EXPOSE 44310


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CarbonNeutral.Identity.Admin/CarbonNeutral.Identity.Admin.csproj", "src/CarbonNeutral.Identity.Admin/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/CarbonNeutral.Identity.Admin.EntityFramework.Shared.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/"]
COPY ["src/CarbonNeutral.Identity.Shared/CarbonNeutral.Identity.Shared.csproj", "src/CarbonNeutral.Identity.Shared/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/CarbonNeutral.Identity.Admin.EntityFramework.MySql/CarbonNeutral.Identity.Admin.EntityFramework.MySql.csproj", "src/CarbonNeutral.Identity.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/CarbonNeutral.Identity.Admin/CarbonNeutral.Identity.Admin.csproj"
COPY . .
WORKDIR "/src/src/CarbonNeutral.Identity.Admin"
RUN dotnet build "CarbonNeutral.Identity.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarbonNeutral.Identity.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "CarbonNeutral.Identity.Admin.dll"]