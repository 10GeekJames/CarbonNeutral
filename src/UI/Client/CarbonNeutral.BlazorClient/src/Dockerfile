FROM nginx:alpine as final
EXPOSE 5020/tcp

FROM local:carbonneutral-shared-base AS build
WORKDIR /
COPY --from=local:carbonneutral-shared-base .  .

COPY ./src/UI/Client/CarbonNeutral.BlazorClient/src/CarbonNeutral.BlazorClient.csproj /src/UI/Client/CarbonNeutral.BlazorClient/src/CarbonNeutral.BlazorClient.csproj
RUN dotnet restore "/src/UI/Client/CarbonNeutral.BlazorClient/src/CarbonNeutral.BlazorClient.csproj"

FROM build as publish
WORKDIR /

COPY ./src/UI/Client/CarbonNeutral.BlazorClient/src/ src/UI/Client/CarbonNeutral.BlazorClient/src/
RUN dotnet publish "/src/UI/Client/CarbonNeutral.BlazorClient/src/CarbonNeutral.BlazorClient.csproj" -c Release -o /app/publish

FROM final
WORKDIR /usr/share/nginx/html

COPY --from=publish ./app/publish/wwwroot/ /etc/nginx/html/
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
#ENTRYPOINT ["dotnet", "CarbonNeutral.BlazorClient.dll"]

WORKDIR /
COPY ./src/UI/Client/CarbonNeutral.BlazorClient/src/ngix.conf /etc/nginx/nginx.conf
COPY ./src/UI/Client/CarbonNeutral.BlazorClient/src/entrypoint.sh .
#RUN chmod +x ./entrypoint.sh
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
CMD ["nginx", "-g", "daemon off;"]
 
#CMD /bin/bash ./entrypoint.sh
