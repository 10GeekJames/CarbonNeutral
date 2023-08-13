# syntax=docker/dockerfile:1
FROM local:carbonneutral-shared-base AS build
WORKDIR /

COPY --from=local:carbonneutral-shared-base .  .
COPY ./src/+Modules/Lazy/LiveRoomModule/+Api/+LiveRoomApi/src/LiveRoomApi.csproj   /src/+Modules/Lazy/LiveRoomModule/+Api/+LiveRoomApi/src/
RUN dotnet restore "/src/+Modules/Lazy/LiveRoomModule/+Api/+LiveRoomApi/src/LiveRoomApi.csproj"

COPY ./src/+Modules/Lazy/LiveRoomModule/+Api/+LiveRoomApi/src/                /src/+Modules/Lazy/LiveRoomModule/+Api/+LiveRoomApi/src/
RUN dotnet publish "/src/+Modules/Lazy/LiveRoomModule/+Api/+LiveRoomApi/src/LiveRoomApi.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
EXPOSE 5292/tcp
WORKDIR /

COPY --from=build /app/build .
COPY ./src/+Modules/Lazy/LiveRoomModule/+Api/+LiveRoomApi/src/entrypoint.sh .
RUN chmod +x ./entrypoint.sh

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
CMD ["dotnet", "LiveRoomApi.dll"]
#CMD /bin/bash ./entrypoint.sh