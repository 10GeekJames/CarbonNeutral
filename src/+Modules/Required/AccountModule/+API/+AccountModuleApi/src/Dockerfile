# syntax=docker/dockerfile:1
FROM local:wordsearchkingdom-shared-base AS build
WORKDIR /

COPY --from=local:wordsearchkingdom-shared-base .  .
COPY ./src/+Modules/Required/AccountModule/+Api/+AccountModuleApi/src/AccountModuleApi.csproj   /src/+Modules/Required/AccountModule/+Api/+AccountModuleApi/src/
RUN dotnet restore "/src/+Modules/Required/AccountModule/+Api/+AccountModuleApi/src/AccountModuleApi.csproj"

COPY ./src/+Modules/Required/AccountModule/+Api/+AccountModuleApi/src/                /src/+Modules/Required/AccountModule/+Api/+AccountModuleApi/src/
RUN dotnet publish "/src/+Modules/Required/AccountModule/+Api/+AccountModuleApi/src/AccountModuleApi.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
EXPOSE 5278/tcp
WORKDIR /app/build

COPY --from=build /app/build .
COPY ./src/+Modules/Required/AccountModule/+Api/+AccountModuleApi/src/entrypoint.sh .
RUN chmod +x ./entrypoint.sh

FROM runtime AS final
COPY --from=runtime /app/build .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
CMD ["dotnet", "AccountModuleApi.dll"]
#CMD /bin/bash ./entrypoint.sh