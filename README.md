# Nostalgia

A .NET project for managing and syncing large datasets with MySQL using Entity Framework Core. This repository includes application logic, data access, and synchronization tools.

## Table of Contents
- [Project Overview](#project-overview)
- [Getting Started](#getting-started)
- [Database Setup](#database-setup)
- [Reference Data](#reference-data)
- [Testing & Coverage](#testing--coverage)
- [License](#license)

## Project Overview
Nostalgia is designed to efficiently handle, process, and synchronize large volumes of data. It leverages Entity Framework Core for data access and supports MySQL as the backend database.

## Getting Started
Clone the repository and restore dependencies:

```bash
git clone <repo-url>
cd nostalgia
# Restore all projects
dotnet restore
```

## Database Setup
1. Install required packages:

```bash
cd src/Nostalgia.Data
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Relational --version 8.0.13
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.3
```

2. Create and apply the initial migration:

```bash
dotnet ef migrations add InitialMigration
dotnet ef database update
```

3. Start a MySQL container:

```bash
docker run -p 3366:3306 --name nostalgia -e MYSQL_ROOT_PASSWORD=dev -d mysql:8.4.4
```

4. Create the database:

```bash
docker exec -it nostalgia mysql -uroot -p
# In the MySQL shell:
create database nostalgia;
exit
```

5. (Optional) Connect with mycli:

```bash
mycli -h localhost -u root -P 3366 -D nostalgia
select @@version;
```

## Reference Data
- Example directory and file counts for large datasets:

```
directory count: 81  
file count: 85,267  
process finished 04:39:30.5904823  
222GB  

directory count: 1,319  
file count: 171,943  
process finished 00:48:55.0083417  
1.4TB  
```

## Testing & Coverage
Run tests and generate a coverage report using dotCover:

```bash
dotCover cover-dotnet --output=coverage.html --reporttype=HTML --filters=-:"*.Test;-:testhost;-:module=*;class=Nostalgia.Data.Migrations.*" -- test Nostalgia.sln
```

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.