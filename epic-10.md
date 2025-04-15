# Epic 10 - Game Picture
Add a picture to the details of the game.

## General requirements
Please use the following Angular Front-end: [gamestore-ui-app](gamestore-ui-app)  

System should support the following features: 
* Manage game with picture.
* Display game picture.
  

Technical specifications:
* Use the latest stable version of ASP.NET CORE (MVC template).  
* N-layer architecture should be used.  
* Use a built-in service provider.  
* Use SOLID principles.  
* Use JSON as response/request format.  
* Use MS SQL Server.  

### Entities

## Task Description

### E12 US1 - User story 1

Add game endpoint should be updated to receive image in base 64 format.
Request example:
```{xml} 
{
  "game": {...},
  "genres": [...],
  "platforms": [...],
  "publisher": "...",
  "image": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAhYAAA....."
}
```

### E12 US2 - User story 2
Update game endpoint should be updated to receive image in base 64 format.
Request example:
```{xml} 
{
  "game": {...},
  "genres": [...],
  "platforms": [...],
  "publisher": "...",
  "image": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAhYAAA....."
}
```

### E12 US3 - User story 3
Update game deletion in a way to remove game pictures in the scope of this operation.


### E12 US4 - User story 4

Get game image endpoint.
```{xml} 
Url: /games/{key}/image
Type: GET
Response: image file 
```

### E12 US14 - User story 14
Delete a Platform endpoint
```{xml} 
Url: /platforms/{Id}
Type: DELETE
```
 
 
## Non-functional requirement

**E12 NFR1**
Images should be stored in Azure Blob storage.  
**E12 NFR2**
Implement a caching mechanism for the get game image endpoint  