FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY *.sln ./
COPY TicketEngine.UserApi/UserApi.csproj ./
COPY Domain.UserApi/Domain.User.csproj ./
COPY Infrastructure.Data/Infrastructure.Data.csproj ./
RUN dotnet restore "UserApi.csproj"
RUN dotnet restore "Domain.User.csproj"
RUN dotnet restore "Infrastructure.Data.csproj"
COPY . ./
WORKDIR /app/TicketEngine.UserApi
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "UserApi.dll"]