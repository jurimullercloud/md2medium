FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app
COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV INTEGRATION_TOKEN= 
ENV REPO_ADDRESS= 
ENV BRANCH= 
ENV FILE_PATH=
ENV BLOG_TITLE=

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "md2medium-publisher.dll"]



