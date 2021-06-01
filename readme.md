Overview

Basic CRUD api developed using Asp.Net Core and Sql Server.

Both the SQL Server and Dot Net solution are containerized.

A Docker Compose file is used to first start a sql server image.

Once the sql is ready, dot net api image is built, during this process it checks for the sql server and seeds table & data using the Entity Framework Core, code first approach (by running the migrations which is specified in the program.cs file).

Use the http file in the repo to test the api which has all the api listed along with sample data.

test-api.http

![image](https://user-images.githubusercontent.com/19172372/120293067-88e46900-c2e2-11eb-88b2-bcbac16d3d79.png)

![image](https://user-images.githubusercontent.com/19172372/120293343-ca751400-c2e2-11eb-8dd7-ac6e9a7ff80a.png)

