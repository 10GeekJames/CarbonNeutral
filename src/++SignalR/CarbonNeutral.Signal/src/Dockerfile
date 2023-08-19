# syntax=docker/dockerfile:1
FROM local:carbonneutral-shared-base AS build
WORKDIR /

COPY --from=local:carbonneutral-shared-base .  .

COPY ./src/++SignalR/CarbonNeutral.Signal/src/CarbonNeutral.Signal.csproj   src/++SignalR/CarbonNeutral.Signal/src/
RUN dotnet restore "src/++SignalR/CarbonNeutral.Signal/src/CarbonNeutral.Signal.csproj"

COPY ./src/++SignalR/CarbonNeutral.Signal/src/                src/++SignalR/CarbonNeutral.Signal/src/
RUN dotnet publish "src/++SignalR/CarbonNeutral.Signal/src/CarbonNeutral.Signal.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
EXPOSE 5200/tcp
WORKDIR /

COPY --from=build /app/build .
COPY ./src/++SignalR/CarbonNeutral.Signal/src/entrypoint.sh .
RUN chmod +x ./entrypoint.sh

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
CMD ["dotnet", "CarbonNeutral.Signal.dll"]
#CMD /bin/bash ./entrypoint.sh