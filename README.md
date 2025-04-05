# Nostalgia 

cosas

## data

    docker run --name Nostalgia -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Cosa@2025" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
    docker logs Nostalgia

    docker exec -it Nostalgia /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -C
    create database Nostalgia collate SQL_Latin1_General_CP1_CI_AS
    go
    exit

    cd Nostalgia.Data
    # dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet ef migrations add InitialMigration
    dotnet ef databae update