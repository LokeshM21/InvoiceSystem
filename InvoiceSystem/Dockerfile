FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet build -c Release

EXPOSE 8080

CMD ["dotnet", "run"]