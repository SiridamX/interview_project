FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

ENV PATH="$PATH:/root/.dotnet/tools"

COPY ["BackEnd.sln", "./"]
COPY ["BackEnd.Api/BackEnd.Api.csproj", "BackEnd.Api/"]
COPY ["BackEnd.Application/BackEnd.Application.csproj", "BackEnd.Application/"]
COPY ["BackEnd.Domain/BackEnd.Domain.csproj", "BackEnd.Domain/"]
COPY ["BackEnd.Infrastructure/BackEnd.Infrastructure.csproj", "BackEnd.Infrastructure/"]

RUN dotnet restore "BackEnd.Api/BackEnd.Api.csproj"

COPY . .

WORKDIR "/src/BackEnd.Api"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

COPY ./entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]
