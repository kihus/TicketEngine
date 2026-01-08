FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY *.sln ./
COPY TicketEngine.UserApi/TicketEngine.CustomerApi.csproj ./
COPY Domain.TicketEngine.Client/Domain.TicketEngine.CustomerApi.csproj ./
COPY Infrastructure.Data/Infrastructure.CustomerApi.Data.csproj ./
RUN dotnet restore "TicketEngine.CustomerApi.csproj"
RUN dotnet restore "Domain.TicketEngine.CustomerApi.csproj"
RUN dotnet restore "Infrastructure.CustomerApi.Data.csproj"
COPY . ./
WORKDIR /app/TicketEngine.UserApi
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TicketEngine.CustomerApi.dll"]