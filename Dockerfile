
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR ./

# COPY *.csproj ./
# RUN dotnet restore

# COPY /Engine/Examples ./
# RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR ./
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "mentorship-docker-api.dll"]

  # syntax=docker/dockerfile:1
  FROM mcr.microsoft.com/dotnet/sdk:6.0
  COPY ./published/ ./
  WORKDIR ./
  ENTRYPOINT ["dotnet", "mentorship-docker-api.dll"]
  EXPOSE 7086
  EXPOSE 80