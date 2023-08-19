# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS copy-project-files
WORKDIR /

#COPY ./local-nuget/ ./local-nuget/
#COPY ./nuget.config ./nuget.config
RUN apt-get clean && apt-get update && apt-get install -y curl sudo
RUN curl -sL https://deb.nodesource.com/setup_18.x | bash - 
RUN apt-get install -y nodejs

RUN npm install -g yarn
RUN npm upgrade --global yarn
RUN npm install -g sass

COPY ./src/__Kernel/CarbonNeutral.KernelShared/src/CarbonNeutral.KernelShared.csproj                                                    /src/__Kernel/CarbonNeutral.KernelShared/src/CarbonNeutral.KernelShared.csproj

COPY ./src/++SignalR/CarbonNeutral.SignalR/src/CarbonNeutral.SignalR.csproj                                                             /src/++SignalR/CarbonNeutral.SignalR/src
COPY ./src/++SignalR/CarbonNeutral.SignalR.Models/src/CarbonNeutral.SignalR.Models.csproj                                               /src/++SignalR/CarbonNeutral.SignalR.Models/src

COPY ./src/+Modules/Required/AccountModule/____Core/__AccountModuleCore/src/AccountModuleCore.csproj                                    /src/+Modules/Required/AccountModule/____Core/__AccountModuleCore/src/AccountModuleCore.csproj
COPY ./src/+Modules/Required/AccountModule/____Core/_AccountModuleCore.TestData/src/AccountModuleCore.TestData.csproj                   /src/+Modules/Required/AccountModule/____Core/_AccountModuleCore.TestData/src/AccountModuleCore.TestData.csproj
COPY ./src/+Modules/Required/AccountModule/___Infrastructure/AccountModuleInfrastructure/src/AccountModuleInfrastructure.csproj         /src/+Modules/Required/AccountModule/___Infrastructure/AccountModuleInfrastructure/src/AccountModuleInfrastructure.csproj
COPY ./src/+Modules/Required/AccountModule/_Application/_AccountModuleApplication.Shared/src/AccountModuleApplication.Shared.csproj     /src/+Modules/Required/AccountModule/_Application/_AccountModuleApplication.Shared/src/AccountModuleApplication.Shared.csproj
COPY ./src/+Modules/Required/AccountModule/_Application/AccountModuleApplication/src/AccountModuleApplication.csproj                    /src/+Modules/Required/AccountModule/_Application/AccountModuleApplication/src/AccountModuleApplication.csproj
COPY ./src/+Modules/Required/AccountModule/UI/_AccountModuleClientServiceLoader/src/AccountModuleClientServiceLoader.csproj             /src/+Modules/Required/AccountModule/UI/_AccountModuleClientServiceLoader/src/AccountModuleClientServiceLoader.csproj
COPY ./src/+Modules/Required/AccountModule/UI/AccountModuleBlazorModuleAdmin/src/AccountModuleBlazorModuleAdmin.csproj                  /src/+Modules/Required/AccountModule/UI/AccountModuleBlazorModuleAdmin/src/AccountModuleBlazorModuleAdmin.csproj

COPY ./src/+Modules/Required/LiveRoomModule/____Core/__LiveRoomCore/src/LiveRoomCore.csproj                                    /src/+Modules/Required/LiveRoomModule/____Core/__LiveRoomCore/src/LiveRoomCore.csproj
COPY ./src/+Modules/Required/LiveRoomModule/____Core/LiveRoomCore.LiveRoomTestData/src/LiveRoomCore.LiveRoomTestData.csproj                   /src/+Modules/Required/LiveRoomModule/____Core/LiveRoomCore.LiveRoomTestData/src/LiveRoomCore.LiveRoomTestData.csproj
COPY ./src/+Modules/Required/LiveRoomModule/___Infrastructure/LiveRoomInfrastructure/src/LiveRoomInfrastructure.csproj         /src/+Modules/Required/LiveRoomModule/___Infrastructure/LiveRoomInfrastructure/src/LiveRoomInfrastructure.csproj
COPY ./src/+Modules/Required/LiveRoomModule/_Application/_LiveRoomApplication.Shared/src/LiveRoomApplication.Shared.csproj     /src/+Modules/Required/LiveRoomModule/_Application/_LiveRoomApplication.Shared/src/LiveRoomApplication.Shared.csproj
COPY ./src/+Modules/Required/LiveRoomModule/_Application/LiveRoomApplication/src/LiveRoomApplication.csproj                    /src/+Modules/Required/LiveRoomModule/_Application/LiveRoomApplication/src/LiveRoomApplication.csproj
COPY ./src/+Modules/Required/LiveRoomModule/UI/_LiveRoomModuleClientServiceLoader/src/LiveRoomModuleClientServiceLoader.csproj /src/+Modules/Required/LiveRoomModule/UI/_LiveRoomModuleClientServiceLoader/src/LiveRoomModuleClientServiceLoader.csproj
COPY ./src/+Modules/Required/LiveRoomModule/UI/LiveRoomBlazorModuleAdmin/src/LiveRoomBlazorModuleAdmin.csproj                  /src/+Modules/Required/LiveRoomModule/UI/LiveRoomModuleBlazorModuleAdmin/src/LiveRoomBlazorModuleAdmin.csproj

COPY ./src/+Modules/Lazy/WordSearchKingdom/____Core/__WskCore/src/WskCore.csproj                                                        /src/+Modules/Lazy/WordSearchKingdom/____Core/__WskCore/src/WskCore.csproj
COPY ./src/+Modules/Lazy/WordSearchKingdom/____Core/WskCore.WskTestData/src/WskCore.WskTestData.csproj                                  /src/+Modules/Lazy/WordSearchKingdom/____Core/WskCore.WskTestData/src/WskCore.WskTestData.csproj
COPY ./src/+Modules/Lazy/WordSearchKingdom/___Infrastructure/WskInfrastructure/src/WskInfrastructure.csproj                             /src/+Modules/Lazy/WordSearchKingdom/___Infrastructure/WskInfrastructure/src/WskInfrastructure.csproj
COPY ./src/+Modules/Lazy/WordSearchKingdom/_Application/_WskApplication.Shared/src/WskApplication.Shared.csproj                         /src/+Modules/Lazy/WordSearchKingdom/_Application/_WskApplication.Shared/src/WskApplication.Shared.csproj
COPY ./src/+Modules/Lazy/WordSearchKingdom/_Application/WskApplication/src/WskApplication.csproj                                        /src/+Modules/Lazy/WordSearchKingdom/_Application/WskApplication/src/WskApplication.csproj
COPY ./src/+Modules/Lazy/WordSearchKingdom/UI/_WskModuleClientServiceLoader/src/WskModuleClientServiceLoader.csproj                     /src/+Modules/Lazy/WordSearchKingdom/UI/_WskModuleClientServiceLoader/src/WskModuleClientServiceLoader.csproj
COPY ./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModule/src/WskBlazorModule.csproj                                                /src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModule/src/WskBlazorModule.csproj
COPY ./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModuleAdmin/src/WskBlazorModuleAdmin.csproj                                      /src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModuleAdmin/src/WskBlazorModuleAdmin.csproj

COPY ./src/_Common/CarbonNeutral.Common/src/CarbonNeutral.Common.csproj                                                                 /src/_Common/CarbonNeutral.Common/src/CarbonNeutral.Common.csproj

FROM copy-project-files AS restore-all
WORKDIR /
COPY --from=copy-project-files .  .

RUN dotnet restore ./src/__Kernel/CarbonNeutral.KernelShared/src/CarbonNeutral.KernelShared.csproj

RUN dotnet restore ./src/++SignalR/CarbonNeutral.SignalR/src/CarbonNeutral.SignalR.csproj                                                             
RUN dotnet restore ./src/++SignalR/CarbonNeutral.SignalR.Models/src/CarbonNeutral.SignalR.Models.csproj                                               

RUN dotnet restore ./src/+Modules/Required/AccountModule/____Core/__AccountModuleCore/src/AccountModuleCore.csproj
RUN dotnet restore ./src/+Modules/Required/AccountModule/____Core/_AccountModuleCore.TestData/src/AccountModuleCore.TestData.csproj
RUN dotnet restore ./src/+Modules/Required/AccountModule/___Infrastructure/AccountModuleInfrastructure/src/AccountModuleInfrastructure.csproj
RUN dotnet restore ./src/+Modules/Required/AccountModule/_Application/_AccountModuleApplication.Shared/src/AccountModuleApplication.Shared.csproj
RUN dotnet restore ./src/+Modules/Required/AccountModule/_Application/AccountModuleApplication/src/AccountModuleApplication.csproj
RUN dotnet restore ./src/+Modules/Required/AccountModule/UI/_AccountModuleClientServiceLoader/src/AccountModuleClientServiceLoader.csproj
RUN dotnet restore ./src/+Modules/Required/AccountModule/UI/AccountModuleBlazorModuleAdmin/src/AccountModuleBlazorModuleAdmin.csproj

RUN dotnet restore ./src/+Modules/Required/LiveRoomModule/____Core/__LiveRoomCore/src/LiveRoomCore.csproj
RUN dotnet restore ./src/+Modules/Required/LiveRoomModule/____Core/LiveRoomCore.LiveRoomTestData/src/LiveRoomCore.LiveRoomTestData.csproj
RUN dotnet restore ./src/+Modules/Required/LiveRoomModule/___Infrastructure/LiveRoomInfrastructure/src/LiveRoomInfrastructure.csproj
RUN dotnet restore ./src/+Modules/Required/LiveRoomModule/_Application/_LiveRoomApplication.Shared/src/LiveRoomApplication.Shared.csproj
RUN dotnet restore ./src/+Modules/Required/LiveRoomModule/_Application/LiveRoomApplication/src/LiveRoomApplication.csproj
RUN dotnet restore ./src/+Modules/Required/LiveRoomModule/UI/_LiveRoomModuleClientServiceLoader/src/LiveRoomModuleClientServiceLoader.csproj
RUN dotnet restore ./src/+Modules/Required/LiveRoomModule/UI/LiveRoomBlazorModuleAdmin/src/LiveRoomBlazorModuleAdmin.csproj

RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/____Core/__WskCore/src/WskCore.csproj
RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/____Core/WskCore.WskTestData/src/WskCore.WskTestData.csproj
RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/___Infrastructure/WskInfrastructure/src/WskInfrastructure.csproj
RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/_Application/_WskApplication.Shared/src/WskApplication.Shared.csproj
RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/_Application/WskApplication/src/WskApplication.csproj
RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/UI/_WskModuleClientServiceLoader/src/WskModuleClientServiceLoader.csproj
RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModule/src/WskBlazorModule.csproj
RUN dotnet restore ./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModuleAdmin/src/WskBlazorModuleAdmin.csproj

RUN dotnet restore ./src/_Common/CarbonNeutral.Common/src/CarbonNeutral.Common.csproj


FROM restore-all AS copy-the-rest-of-the-files
WORKDIR /
COPY --from=restore-all .  .

COPY ./src/__Kernel/CarbonNeutral.KernelShared/src/                                             /src/__Kernel/CarbonNeutral.KernelShared/src/

COPY ./src/++SignalR/CarbonNeutral.SignalR/src/                                                 /src/++SignalR/CarbonNeutral.SignalR/src
COPY ./src/++SignalR/CarbonNeutral.SignalR.Models/src/                                          /src/++SignalR/CarbonNeutral.SignalR.Models/src

COPY ./src/+Modules/Required/AccountModule/____Core/__AccountModuleCore/src/                    /src/+Modules/Required/AccountModule/____Core/__AccountModuleCore/src/
COPY ./src/+Modules/Required/AccountModule/____Core/_AccountModuleCore.TestData/src/            /src/+Modules/Required/AccountModule/____Core/_AccountModuleCore.TestData/src/
COPY ./src/+Modules/Required/AccountModule/___Infrastructure/AccountModuleInfrastructure/src/   /src/+Modules/Required/AccountModule/___Infrastructure/AccountModuleInfrastructure/src/
COPY ./src/+Modules/Required/AccountModule/__Data/AccountModule.Data/src/                       /src/+Modules/Required/AccountModule/__Data/AccountModule.Data/src/       
COPY ./src/+Modules/Required/AccountModule/_Application/_AccountModuleApplication.Shared/src/   /src/+Modules/Required/AccountModule/_Application/_AccountModuleApplication.Shared/src/
COPY ./src/+Modules/Required/AccountModule/_Application/AccountModuleApplication/src/           /src/+Modules/Required/AccountModule/_Application/AccountModuleApplication/src/
COPY ./src/+Modules/Required/AccountModule/UI/_AccountModuleClientServiceLoader/src/            /src/+Modules/Required/AccountModule/UI/_AccountModuleClientServiceLoader/src/
COPY ./src/+Modules/Required/AccountModule/UI/AccountModuleBlazorModuleAdmin/src/               /src/+Modules/Required/AccountModule/UI/AccountModuleBlazorModuleAdmin/src/

COPY ./src/+Modules/Required/LiveRoomModule/____Core/__LiveRoomCore/src/                    /src/+Modules/Required/LiveRoomModule/____Core/__LiveRoomCore/src/
COPY ./src/+Modules/Required/LiveRoomModule/____Core/LiveRoomCore.LiveRoomTestData/src/            /src/+Modules/Required/LiveRoomModule/____Core/LiveRoomCore.LiveRoomTestData/src/
COPY ./src/+Modules/Required/LiveRoomModule/___Infrastructure/LiveRoomInfrastructure/src/   /src/+Modules/Required/LiveRoomModule/___Infrastructure/LiveRoomInfrastructure/src/
COPY ./src/+Modules/Required/LiveRoomModule/__Data/LiveRoomApplication.Data/src/                       /src/+Modules/Required/LiveRoomModule/__Data/LiveRoomApplication.Data/src/       
COPY ./src/+Modules/Required/LiveRoomModule/_Application/_LiveRoomApplication.Shared/src/   /src/+Modules/Required/LiveRoomModule/_Application/_LiveRoomApplication.Shared/src/
COPY ./src/+Modules/Required/LiveRoomModule/_Application/LiveRoomApplication/src/           /src/+Modules/Required/LiveRoomModule/_Application/LiveRoomApplication/src/
COPY ./src/+Modules/Required/LiveRoomModule/UI/_LiveRoomModuleClientServiceLoader/src/            /src/+Modules/Required/LiveRoomModule/UI/_LiveRoomModuleClientServiceLoader/src/
COPY ./src/+Modules/Required/LiveRoomModule/UI/LiveRoomBlazorModuleAdmin/src/               /src/+Modules/Required/LiveRoomModule/UI/LiveRoomBlazorModuleAdmin/src/

COPY ./src/+Modules/Lazy/WordSearchKingdom/____Core/__WskCore/src/                              /src/+Modules/Lazy/WordSearchKingdom/____Core/__WskCore/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/____Core/WskCore.WskTestData/src/                    /src/+Modules/Lazy/WordSearchKingdom/____Core/WskCore.WskTestData/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/___Infrastructure/WskInfrastructure/src/             /src/+Modules/Lazy/WordSearchKingdom/___Infrastructure/WskInfrastructure/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/__Data/WskApplication.Data/src/                      /src/+Modules/Lazy/WordSearchKingdom/__Data/WskApplication.Data/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/_Application/_WskApplication.Shared/src/             /src/+Modules/Lazy/WordSearchKingdom/_Application/_WskApplication.Shared/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/_Application/WskApplication/src/                     /src/+Modules/Lazy/WordSearchKingdom/_Application/WskApplication/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/UI/_WskModuleClientServiceLoader/src/                /src/+Modules/Lazy/WordSearchKingdom/UI/_WskModuleClientServiceLoader/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModule/src/                              /src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModule/src/
COPY ./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModuleAdmin/src/                         /src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModuleAdmin/src/

COPY ./src/_Common/CarbonNeutral.Common/src/                                                    /src/_Common/CarbonNeutral.Common/src/

FROM copy-the-rest-of-the-files
WORKDIR /
COPY --from=copy-the-rest-of-the-files .  .
RUN dotnet publish -c Release "./src/__Kernel/CarbonNeutral.KernelShared/src/"
RUN dotnet build "./src/_Common/CarbonNeutral.Common/src/"
RUN dotnet publish -c Release "./src/_Common/CarbonNeutral.Common/src/"

#ADD "https://www.random.org/cgi-bin/randbyte?nbytes=10&format=h" skipcache
#RUN dotnet tool install --global dotnet-ef
#ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /src/+Modules/Lazy/WordSearchKingdom/__Data/WskApplication.Data/src/
#RUN "dotnet ef database update"
#RUN dotnet run
#RUN rm appsettings.json
#RUN rm appsettings.Development.json

#WORKDIR /src/+Modules/Required/AccountModule/__Data/AccountModule.Data/src/
#RUN "dotnet ef database update"
#RUN dotnet run
#RUN rm appsettings.json
#RUN rm appsettings.Development.json

WORKDIR /

#RUN dotnet build "./src/+Modules/Required/AccountModule/____Core/__AccountModuleCore/src/"
#RUN dotnet build "./src/+Modules/Required/AccountModule/____Core/_AccountModuleCore.TestData/src/"
#RUN dotnet build "./src/+Modules/Required/AccountModule/___Infrastructure/AccountModuleInfrastructure/src/"
#RUN dotnet build "./src/+Modules/Required/AccountModule/_Application/_AccountModuleApplication.Shared/src/"
#RUN dotnet build "./src/+Modules/Required/AccountModule/_Application/AccountModuleApplication/src/"
#RUN dotnet build "./src/+Modules/Required/AccountModule/UI/_AccountModuleClientServiceLoader/src/"
#RUN dotnet build "./src/+Modules/Required/AccountModule/UI/AccountModuleBlazorModuleAdmin/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/____Core/__WskCore/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/____Core/WskCore.WskTestData/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/___Infrastructure/WskInfrastructure/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/_Application/_WskApplication.Shared/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/_Application/WskApplication/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/UI/_WskModuleClientServiceLoader/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModule/src/"
#RUN dotnet build "./src/+Modules/Lazy/WordSearchKingdom/UI/WskBlazorModuleAdmin/src/"
#RUN dotnet build "./src/_Common/CarbonNeutral.Common/src/"
