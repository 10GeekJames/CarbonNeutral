FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 44302
EXPOSE 44303
EXPOSE 44310

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

RUN apt-get update && apt-get install -y curl sudo
RUN curl -sL https://deb.nodesource.com/setup_18.x | bash - 
RUN apt-get install -y nodejs

RUN npm install -g yarn
RUN npm upgrade --global yarn
RUN npm install -g sass

COPY src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.STS.Identity/entrypoint.sh .
COPY src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.STS.Identity/ngix.conf .

COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.STS.Identity/CarbonNeutral.Identity.STS.Identity.csproj /src/CarbonNeutral.Identity.STS.Identity/CarbonNeutral.Identity.STS.Identity.csproj
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Shared/CarbonNeutral.Identity.Shared.csproj /src/CarbonNeutral.Identity.Shared/CarbonNeutral.Identity.Shared.csproj
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin/CarbonNeutral.Identity.Admin.csproj /src/CarbonNeutral.Identity.Admin/CarbonNeutral.Identity.Admin.csproj
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/CarbonNeutral.Identity.Admin.EntityFramework.Shared.csproj /src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/CarbonNeutral.Identity.Admin.EntityFramework.Shared.csproj
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer.csproj /src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer.csproj
#COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL.csproj /src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL.csproj

RUN dotnet restore /src/CarbonNeutral.Identity.STS.Identity/CarbonNeutral.Identity.STS.Identity.csproj
#RUN dotnet restore /src/CarbonNeutral.Identity.Shared/CarbonNeutral.Identity.Shared.csproj
#RUN dotnet restore /src/CarbonNeutral.Identity.Admin/CarbonNeutral.Identity.Admin.csproj
#RUN dotnet restore /src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/CarbonNeutral.Identity.Admin.EntityFramework.Shared.csproj
#RUN dotnet restore /src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer.csproj
#RUN dotnet restore /src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL.csproj

WORKDIR /
       
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.STS.Identity/ /src/CarbonNeutral.Identity.STS.Identity/
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Shared/ /src/CarbonNeutral.Identity.Shared/
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin/ /src/CarbonNeutral.Identity.Admin/
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/ /src/CarbonNeutral.Identity.Admin.EntityFramework.Shared/
COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/ /src/CarbonNeutral.Identity.Admin.EntityFramework.SqlServer/
#COPY ./src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/ /src/CarbonNeutral.Identity.Admin.EntityFramework.PostgreSQL/

#RUN dotnet build "/src/CarbonNeutral.Identity.STS.Identity/CarbonNeutral.Identity.STS.Identity.csproj" -c Release

FROM build AS publish
RUN dotnet publish /src/CarbonNeutral.Identity.STS.Identity/CarbonNeutral.Identity.STS.Identity.csproj -c Release -o /app/publish

FROM base AS final
COPY ./build/local-reverse-proxy/domain.crt .
COPY ./build/local-reverse-proxy/domain.rsa .
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "CarbonNeutral.Identity.STS.Identity.dll"]