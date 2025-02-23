# Epic 8 - NoSQL database
Our customer has bought the Northwind Online Store, which is still in active use.
Extend Online Game Store with their database and the application must work with 2 databases from now.
You can find all the needed information in mongo.zip.


## General requirements

Please use the following Angular Front-end: [gamestore-ui-app](gamestore-ui-app)

Existing [MongoDB](mongo)

System should support the following features: 
* Two databases as data storage.
* Operations logging.   

## Additional Requirements
#### Products
	A user should be able to perform the same actions with products from Northwind Online Store in Game Store: view, edit, delete, buy, comment, use the same filter options, etc.  


#### Orders History
	Order history should contain orders from both databases.
	Start/end date query parameters are optional, if the value is not populated then should be treated as unlimited.


#### Northwind database entities
	Northwind database is read-only, neither the data scheme nor the data content must be changed. Only changes required by task description are allowed.


#### Entity changes logs
	A new model should be created for logs inside the Northwind database.


#### Shippers
	Shippers should be stored only in the Northwind database, the game store app will not add new ones.


#### Game store Database Entities
	Entities in an SQL database must have the same set of attributes as in NoSQL: Suppliers, Products, Orders, 		Order details, and Categories.	


#### Operations
	Products, Suppliers, and Categories must have CRUD as before, regardless database.


#### Product mapping
	Product can be used as game in our system.
	Northwind does not guarantee any product property is unique,	
	Add a new game key field into Northwind db managed only by the game store app. This field should be used for mapping products and should be unique for two databases.


#### Product view counter
	Product views count field can be added in Mongo schema.


#### Supplier
	Supplier can be used as publisher in our system.
	Use supplier name as unique key for mapping entities in two databases.


#### Orders
	All orders from Northwind should be used only for reading.


#### Data Transfer Objects
	Any existing endpoint results should not be changed in this task.


#### Categories
	Category can be used as genre in our system.


#### Product count 
	Products count value should be synced for both databases and recalculated after order payment.


#### Damaged data                                      
	After years of using Northwind contains some broken data, this should be handled by the Game store app.




## Task Description

### E08 US1 - User story 1

Get Shippers endpoint.
```{xml} 
Url: /shippers
Type: GET
Response: Since shipper model can be dynamic, use a free content structure.
```

### E08 US2 - User story 2
Get orders history endpoint.
```{xml} 
Url: /orders/history
Type: GET
Response example:
[
  {
    "id": "769d6ae7-9ec1-4c78-8401-25c672afc10b",
    "customerId": "4dee81a7-10cc-44b9-8866-920711f70b98",
    "date": "2023-11-26T12:15:28.8416459+02:00"
  },
  {
    "id": "33f3a9d1-0c84-4dc1-8861-ae46cb15391f",
    "customerId": "510f9d71-8fc3-470c-a34d-02795ffa66e0",
    "date": "2023-11-24T12:15:28.8416998+02:00"
  }
]
```

### E08 US3 - User story 3
Extend SQL database with the fields presented in MongoDB


### E08 US4 - User story 4
Extend CRUD operations to perform them for entities for any database.


### E08 US5 - User story 5
Implement unit-in-stock count sync for two databases.


### E08 US6 - User story 6
Implement duplicate management by the next criteria:
* If there is a duplicate between our DB and MongoDB – the item in our DB is a priority.
* If there are two same items in MongoDB – the first found item must be used.


### E08 US7 - User story 7
Implement Mongo DB items update by the next schema:
* Once the User edits the items in Mongo DB – the item must be copied to the game store database and the update performed.
* Mongo DB data should be not affected by any game store CRUD operations.
 
 
## Non-functional requirement
**E08 NFR1**  
A C# driver with IQueryable for read operations in MongoDB should be used.  
**E08 NFR2**  
	A FilterDefinition/UpdateDefinition for update operations in MongoDB should be used.  
**E08 NFR3**  
	A raw query for insert/delete in the MongoDB should be used.  
**E08 NFR4**  
	All entity changes in both databases must be logged into the NoSQL database. The log should include the date and time, action name, entity type, old version, and new version.  
**E08 NFR5 [Optional]**  
	Use a structural logging approach for entity change logs.  
**E08 NFR6 [Optional]**  
	Use the Database First approach for Northwind database integration.  
