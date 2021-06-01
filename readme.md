Solution Overview:

Basic CRUD api developed using Asp.Net Core and Sql Server.

Both the SQL Server and Dot Net solution are containerized.

A Docker Compose file is used to first start a sql server image.

Once the sql is ready, dot net api image is built, during this process it checks for the sql server and seeds table & data using the Entity Framework Core, code first approach (by running the migrations which is specified in the program.cs file).

![image](https://user-images.githubusercontent.com/19172372/120293067-88e46900-c2e2-11eb-88b2-bcbac16d3d79.png)
