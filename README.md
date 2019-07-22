# Reaction API

This api was created to provide data for my another project in React, called [Reaction](https://github.com/caiocolaiacovo/Reaction).

Some architectural patterns and designs:
- Onion architecture
- CQS (Command Query Separation)

Note: Avoid use all those patterns on every project. This is overengineering. I use here for educational purposes.

## Requirements
- Dotnet Core 2.2
- Sql Server (you can use [this](https://docs.microsoft.com/pt-br/sql/linux/quickstart-install-connect-docker?view=sql-server-2017&pivots=cs1-bash) official docker image from Microsoft)

## How to run

- <code>dotnet restore</code>
- <code>dotnet run</code>

## SQL Server scripts
```
CREATE DATABASE Reaction
GO
USE Reaction
GO
CREATE LOGIN administrator WITH PASSWORD = '<YourStrong@Passw0rd>'
GO
CREATE USER administrator FROM LOGIN administrator
GO
ALTER LOGIN administrator WITH DEFAULT_DATABASE = Reaction
GO
EXEC sp_addrolemember 'db_owner', 'administrator'
GO
```