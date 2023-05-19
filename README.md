# Setup of service:

## Add nuget package for dependencies:
```
dotnet add package DotNetEnv --version 2.5.0
dotnet add package Elastic.Clients.Elasticsearch --version 8.1.1
dotnet add package Elasticsearch.Net --version 7.17.5
dotnet add package HotChocolate.AspNetCore --version 13.0.5
dotnet add package HotChocolate.Data --version 13.0.5
dotnet add package HotChocolate.Execution --version 13.0.5
dotnet add package HotChocolate.Subscriptions --version 13.0.5
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.5
dotnet add package MySql.Data --version 8.0.33
dotnet add package NEST --version 7.17.5
dotnet add package Newtonsoft.Json --version 13.0.3
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package RabbitMQ.Client --version 6.5.0
```

## Make sure Elasticsearch and rabbitMQ is running in Docker.

## Add .env file for MySQL username, password and port
```
MYSQL_USER=<username>
MYSQL_PASSWORD=<password>
PORT=<port>
```
