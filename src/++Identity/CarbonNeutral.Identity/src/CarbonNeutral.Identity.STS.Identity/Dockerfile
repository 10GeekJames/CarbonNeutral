FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 44310

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ./src/++Identity/ /src/++Identity/                    
RUN dotnet restore /src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.STS.Identity/CarbonNeutral.Identity.STS.Identity.csproj

FROM build AS publish

RUN apt-get update && apt-get install -y curl sudo
RUN curl -sL https://deb.nodesource.com/setup_18.x | bash - 
RUN apt-get install -y nodejs

RUN npm install -g yarn
RUN npm upgrade --global yarn
RUN npm install -g sass

# Core dependencies
RUN echo "NODE Version:" && node --version
RUN echo "NPM Version:"  && npm --version
RUN echo "YARN Version:" && yarn --version

RUN dotnet publish /src/++Identity/CarbonNeutral.Identity/src/CarbonNeutral.Identity.STS.Identity/CarbonNeutral.Identity.STS.Identity.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "CarbonNeutral.Identity.STS.Identity.dll"]