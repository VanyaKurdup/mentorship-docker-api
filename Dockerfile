﻿
 FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
 WORKDIR ./src

 COPY . .
 RUN dotnet restore

 RUN dotnet publish -c Release -o out

 FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
 COPY --from=build-env /src/out .
 ENTRYPOINT ["dotnet", "mentorship-docker-api.dll"]