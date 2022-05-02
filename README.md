# AnnounceMongo

In this soulution I create a REST API using C# and MongoDb database.

Domain : in this directory we have our entities.

Dal : Infrastructure : in this folder we have AnnounceDbContext.cs for store our data

Application : in this folder we have two directory Common and DTO. Common (for our interfaces, mapping, services and pagination) and DTO (for data transfer object) 

UI : in this folder we have our API with AnnounceController:
- method CreateAnnounce ( create announce )
- method GetAllAnnounce ( return list of announce use pagination )
- mathod GetByName ( return announce by Name )
