# syntax=docker/dockerfile:1
FROM local:wordsearchkingdom-shared-base AS build
WORKDIR /

COPY --from=local:wordsearchkingdom-shared-base .  .
COPY ./src/+Modules/Lazy/WordSearchKingdom/+Api/+WskApi/src/WskApi.csproj   /src/+Modules/Lazy/WordSearchKingdom/+Api/+WskApi/src/
RUN dotnet restore "/src/+Modules/Lazy/WordSearchKingdom/+Api/+WskApi/src/WskApi.csproj"

COPY ./src/+Modules/Lazy/WordSearchKingdom/+Api/+WskApi/src/                /src/+Modules/Lazy/WordSearchKingdom/+Api/+WskApi/src/
RUN dotnet publish "/src/+Modules/Lazy/WordSearchKingdom/+Api/+WskApi/src/WskApi.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
EXPOSE 5290/tcp
WORKDIR /

COPY --from=build /app/build .
COPY ./src/+Modules/Lazy/WordSearchKingdom/+Api/+WskApi/src/entrypoint.sh .
RUN chmod +x ./entrypoint.sh

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
CMD ["dotnet", "WskApi.dll"]
#CMD /bin/bash ./entrypoint.sh