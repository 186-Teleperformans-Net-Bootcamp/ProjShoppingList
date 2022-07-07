# Teleperformance Final Project

## ---Shopping List---

## Technologies

* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/), [FluentApi](https://docs.microsoft.com/tr-tr/ef/ef6/modeling/code-first/fluent/types-and-properties)
* [XUnit](https://xunit.net/), [Moq](https://github.com/moq)
* [Newtonsoft](https://www.newtonsoft.com)
* [Redis](https://redis.io/)
* [Microsoft identity](https://docs.microsoft.com/tr-tr/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio)

## Databases
* [MSSQL](https://www.microsoft.com/tr-tr/sql-server/sql-server-2019)
* [PostgreSql](https://www.postgresql.org/)
* [MongoDb](https://www.mongodb.com/)


- ## Contents 
  * [1.Development Environment](#develop)
  * [2.Docker](#docker)
  * [3.Architecture](#architecture)
  * [4.Application](#infrastructure)
  * [5.Infrastructure](#application)
  * [6.Domain](#domain)
  * [7.BackgroundServices](#backgroundServices)
  * [8.Tests](#tests)
    * [8.1.Unit Test](#unittest)
    * [8.1.Integration Test](#integrationtest)
  * [9.Databases](#databases)
# Develop

## RabbitMq
```bash 
   docker run -d --hostname rabbit --name rabbit rabbitmq:3-management
```

 ## MongoDb
 ```bash 
    docker run --name mongodb -d -p 27017:27017 mongo
```

## PostgreSql
```bash 
    docker run --name <Container_Name> -e POSTGRES_PASSWORD=<ROOT_Password> -d -p 5432:5432 -v 
```
# Docker

## **DockerCLI**
```bash 
    docker ps => for Lİsting container
```
```bash 
   docker inspect {containerId} for container detail
```
## **Docker Containers**

![DockerContainers](https://user-images.githubusercontent.com/77523736/177659996-34773b02-218c-4dbe-937e-1bd781606b62.png)
<hr>

![DockerPs](https://user-images.githubusercontent.com/77523736/177661719-91574dd1-dd6f-434f-a437-134cd811db96.png)

# Architecture

**This project established with clean architecture.**
* **Folder Src**
  1. UI (Presentation)
  2. Application
  3. Infrastructure
  4. Domain
  5. BackgroundServices
* **Folder tests**
  1. UI tests (unit)
  2. Integration tests

![CleanArchitecture](https://user-images.githubusercontent.com/77523736/177662618-f2aa3879-9f22-4305-a586-b64080c4148f.png)

<br/>

# UI
=>  It is the layer where the endpoints are located. It is startup project. This is the part which requests are first met.

![UI](https://user-images.githubusercontent.com/77523736/177664221-717db88e-c9a0-49bb-9f8c-3b12276b66e0.png)

# Application
=> **It is the abstraction layer.All dto's, interfaces, behaviours etc. are in this layer.**

<br>

![Application](https://user-images.githubusercontent.com/77523736/177666118-84d2eb41-cbe5-4495-b3ff-e797f3e06b58.png)

# Infrastructure
=> **Is the layer where services are located. All services (with db or without)
are in this layer. And this layer contains context objects.**

<br>

![Infrastructure](https://user-images.githubusercontent.com/77523736/177666413-8d41bae5-a090-488b-ab57-d58d6003dbc9.png)

# Domain
=> **This is entities,value objects and enums layer.**

<br>

![Domain](https://user-images.githubusercontent.com/77523736/177666660-436df93e-bdea-4728-9e9e-d8d1253f0e3b.png)


# Backgroundservices
=> If a list completed, the completed list pass to queue by producer. Later consumer reads queue and catch this data. After all, consumer write data to postgresql on api. 
* **RabbitMq**
  1. Producer
  2. Consumer

<br>

  ![RabbitMq](https://user-images.githubusercontent.com/77523736/177667735-4ac7ac70-d8ed-4595-9f22-248f106db583.png)

# Tests

## Unit Test
=> **Unit Testing is a way to test a unit, the smallest piece of code that can be logically isolated in a system.**

<br>

![TestUI](https://user-images.githubusercontent.com/77523736/177666823-a73d71c8-aef6-4565-b6fc-7bc9fb276fda.png)


## Integration Test
=> **Integration testing aims to test whether different components (units) of the system work together correctly.**

<br>

![TestIntegrations](https://user-images.githubusercontent.com/77523736/177666973-dc11f0d1-9dcd-4802-850c-6f8df054eb1f.png)

# Databases

### Sql Server
=> For standart entities

![SqlRelations](https://user-images.githubusercontent.com/77523736/177668126-cd1c4be0-23fd-4fd7-aaa0-55535b4247cd.png)

### PostgreSql
=> For completed list (admin)
```javascript
Package Manager Console
 add-migration mig_AdminPostgreSql -context ProjShoppingListPostgreSqlDbContext 

 : We have to assign context name
```

### MongoDb
=> For custom log on docker.