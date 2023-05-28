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
## Add migration
```
dotnet tool install --global dotnet-ef
dotnet ef migrations add initialmigration 
dotnet ef database update 
```

If dotnet-ef command dont install use:
```
dotnet tool install --global dotnet-ef --ignore-failed-sources
```

## Make sure Elasticsearch and rabbitMQ is running in Docker.
```
docker pull docker.elastic.co/elasticsearch/elasticsearch:7.15.0
docker run -d --name elasticsearch -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:7.15.0
```

## RabbitMQ
```
docker run -d --hostname rabbitmq --name rabbitmq-container -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

## Add .env file for MySQL username, password and port
```
MYSQL_USER=<username>
MYSQL_PASSWORD=<password>
PORT=<port>
```
