# Nostalgia 

cosas

## data

    cd Nostalgia.Data
    dotnet add package Pomelo.EntityFrameworkCore.MySql

    dotnet add package Microsoft.EntityFrameworkCore.Relational --version 8.0.13
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.3
    dotnet ef migrations add InitialMigration
    dotnet ef database update

    docker run -p 3366:3306 --name nostalgia -e MYSQL_ROOT_PASSWORD=dev -d mysql:8.4.4
    docker exec -it nostalgia mysql -uroot -p
    create database nostalgia;
    exit

    mycli -h localhost -u root -P 3366 -D nostalgia
    select @@version

## reference

directory count: 81
file count: 85267
process finished 04:39:30.5904823    
222GB

directory count: 1319
file count: 171943
process finished 00:48:55.0083417
1.4TB