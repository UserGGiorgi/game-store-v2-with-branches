# Epic 4 - Enhancements and UI integration


## General requirements

Please use the following Angular Front-end: [gamestore-ui-app](gamestore-ui-app)

System should support the following features: 
* UI integration with API
* CRUD for publishers
* Get games by publisher name
* Appropriate status codes on endpoints results

Technical specifications:
* Use the latest stable version of ASP.NET CORE (MVC template).  
* N-layer architecture should be used.  
* Use a built-in service provider.  
* Use SOLID principles.  
* Use JSON as response/request format.  
* Use MS SQL Server.  

### Entities
**Game**
* **Id:** Guid, required, unique
* **Name:** String, required
* **Key:** String, required, unique
* **Description:** String, optional
* **Price:** Double, required
* **Unit In Stock:** int, required.
* **Discount:** int, required.
* **PublisherId:** Guid, required

**Publisher**
* **Id:** Guid, required, unique
* **CompanyName:** String, required, unique.
* **HomePage:** string, optional
* **Description:** string, optional


## Additional requirements

**Game**
* A Game entity must be updated with the additional properties.
* The all game-related endpoint contracts must be updated accordingly.
* The all game-related business models must be updated accordingly.

**Validation**
* If model validation passed successfully, then the system processes the request and returns a success status code.
* If model validation fails, then the system returns the appropriate status code with validation error(s).




### E04 US1 - User story 1
A game create and update endpoints should contain server-side validation.
All fields are mandatory and should be populated with correct data.
The Genres field should contain IDs of existing genres.
The platforms field should contain IDs of existing platforms.
The publisher field should be referenced to the existing publisher.
Valid create a game request example:
```{xml} 
{
  "game": {
    "name": "Game Name",
    "key": "key1",
    "description": "string",
    "price": 10,
    "unitInStock": 220,
    "discount": 5
  },
  "genres": [
    "77c06fc6-f8a1-46f9-af03-2793e5001155",
    "77c06fc6-f8a1-46f9-af03-2793e5001156"
  ],
  "platforms": [
     "77c06fc6-f8a1-46f9-af03-2793e5001112",
     "77c06fc6-f8a1-46f9-af03-2793e5001133"
  ],
  "publisher": "77c06fc6-f8a1-46f9-af03-2793e500112c"
}
```

### E04 US2 - User story 2
Get game endpoints should contain updated game model in response content.
Response example:

```{xml} 
{
  "id": "eac62da5-eb32-4378-8407-0448726237d5",
  "description": "string",
  "key": "key1",
  "name": "Game Name",
  "price": 10,
  "discount": 5,
  "unitInStock": 220
}
```

### E04 US3 - User story 3
Add a new publisher endpoint.

```{xml} 
Url: /publishers
Type: POST
Validation: All fields are mandatory and should be populated with correct data, name should be unique.
Request Example:
{
  "publisher": {
    "companyName": "Test Name",
    "homePage": "https://localhost:7091/swagger/index.html",
    "description": "Some text"
  }
}
```


### E04 US4 - User story 4
Get publisher by company name endpoint
```{xml} 
Url: /publishers/{companyName}
Type: GET
Response Example:
{
  "id": "0f7f61ac-babe-423d-a6fe-a5a6c842eacd",
  "companyName": "Test Name",
  "description": "Some text",
  "homePage": "https://localhost:7091/swagger/index.html"
} 
```

Get all publishers
```{xml} 
Url: /publishers
Type: GET
Response Example:
[
  {
    "id": "77c06fc6-f8a1-46f9-af03-2793e500112c",
    "companyName": "Updated text",
    "description": "Updated text",
    "homePage": "https://localhost:7091/swagger/index.html"
  },
  {
    "id": "0f7f61ac-babe-423d-a6fe-a5a6c842eacd",
    "companyName": "Test Name",
    "description": "Some text",
    "homePage": "https://localhost:7091/swagger/index.html"
  }
]
```

Get publisher by game key endpoint.
```{xml} 
Url: /games/{key}/publisher
Type: GET
Response example:
{
  "id": "77c06fc6-f8a1-46f9-af03-2793e500112c",
  "companyName": "test",
  "description": "test text",
  "homePage": "test url"
} 
```

### E04 US5 - User story 5

A platform create and update endpoints should contain server-side validation.
The type field is mandatory and should be populated with correct data.
Valid create a platform request example:
```{xml} 
{
  "platform": {
    "type": "Valid"
  }
}
```

### E04 US6 - User story 6
A genre create and update endpoints should contain server-side validation.
The name field is mandatory and should be populated with the correct data.
The ParentGenreId field should be referenced to the existing genre.
Cycled references should be prohibited.
Valid create a genre request example:
```{xml} 
{
  "genre": {
    "name": "Valid Name",
    "parentGenreId": null
  }
}
```

### E04 US7 - User story 7
Update Publisher endpoint.
```{xml} 
Url: /publishers
Type: PUT
Validation: All fields are mandatory and should be populated with correct data, name should be unique.
Request Example:
{
  "publisher": {
    "id": "77c06fc6-f8a1-46f9-af03-2793e500112c",
    "companyName": "Updated text",
    "homePage": "https://localhost:7091/swagger/index.html",
    "description": "Updated text"
  }
}
```


### E04 US8 - User story 8
Delete a Publisher endpoint
```{xml} 
Url: /publishers/{Id}
Type: DELETE
```

### E04 US9 - User story 9
Get Games by Publisher name endpoint
```{xml} 
Url: /publishers/{companyName}/games
Type: GET
Response Example:
[
  {
    "id": "1a7c1b17-d629-4a11-af48-49dbb2d79010",
    "description": "",
    "key": "test",
    "name": "test",
    "price": 1,
    "discount": 1,
    "unitInStock": 1
  },
  {
    "id": "d7c8711c-65e1-4a9c-b84e-c9ff8cc5db9e",
    "description": "string",
    "key": "string",
    "name": "string",
    "price": 10,
    "discount": 0,
    "unitInStock": 220
  }
]
```

### E04 US10 - User story 10
The provided UI should be configured to use the developed game store API.
All UI functionalities should work without errors.
 
 
## Non-functional requirement

The cache must be removed from the endpoints.  
**E04 NFR1**  
Get All Games  
Url: /games  
Type: GET  
**E04 NFR2**
Get Game By key  
Url: /games/{key}  
Type: GET  