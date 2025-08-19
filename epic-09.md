# Epic 9 - Authorization


## General requirements

Please use the following Angular Front-end: [gamestore-ui-app](gamestore-ui-app)  

Existing [Authorization microservice](AuthService)

System should support the following features: 
* User Management
* Login
* Roles Management 
* Access by permissions 
  

## Additional Requirements
### Roles
* The system should have the next default roles: Administrator, Manager, Moderator, User, and Guest (not authorized).  
* Custom roles can be created additionally.
* Multiple roles can be assigned to the user.  


#### Admin
* Can manage users and roles.  
* Can see deleted games.  
* Can manage comments for the deleted game.  
* Can edit a deleted game.  


#### Manager
* Can manage business entities: games, genres, publishers, platforms, etc.  
* Can edit orders.  
* Can view orders history.  
* Can’t edit orders from history.  
* Can change the status of an order from paid to shipped.  
* Can't edit a deleted game.  


#### Moderator
* Can manage game comments.
* Can ban users from commenting.

#### User
* Can`t see deleted games.
* Can’t buy a deleted game.
* Can see the games in stock. 
* Can comment game.

#### Guest
* Has read-only access.

#### Comments
* The username should be used as the commenter's name now.

#### Order history
* Order history displays orders older than 30 days by default.


#### Default Roles hierarchy
	Default Roles at the top inherit all accepts and limitations from roles below if other behavior is not specified in the role description.
	Admin => Manager => Moderator => User => Guest

## Task Description

### E09 US1- User story 1
Login endpoint.

```{xml} 
Url: /users/login
Type: POST
Request Example:
{
  "model": {
    "login": "UserName",
    "password": "SuperSecuredPassword",
    "internalAuth": true
  }
}

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
}
```

### E09 US2 - User story 2
Check page access endpoint.
```{xml} 
Url: /users/access
Type: POST
Request Example:
{
  "targetPage": "Genre",
  "targetId": "84ea3383-08c2-48ba-9866-34c7e08e6e61"
}
```

### E09 US3 - User story 3
Get all users endpoint.
```{xml} 
Url: /users
Type: GET
Response Example:
[
  {
    "name": "Vitalii",
    "id": "454d4d01-406b-4a9b-9f8c-3fec63fc9266"
  },
  {
    "name": "John",
    "id": "80fbf934-45e7-49a8-8ae2-868a70bed2bf"
  }
]
```


### E09 US4 - User story 4

Get user by id endpoint.
```{xml} 
Url: /users/{id}
Type: GET
Response Example:
{
  "name": "Vitalii",
  "id": "a997674c-d34d-4074-81d2-fe27d739f55a"
}
```

### E09 US5 - User story 5
Delete user by id endpoint.
```{xml} 
Url: /users/{id}
Type: DELETE
```

### E09 US6 - User story 6
Get all roles endpoint.
```{xml} 
Url: /roles
Type: GET
Response Example:
[
  {
    "name": "Admin",
    "id": "529e960f-79c9-4e25-b3ef-a5ce8cbb42bc"
  },
  {
    "name": "Manager",
    "id": "765f9e20-fb70-4837-8b22-5d280ad9d2d2"
  }
]
```

### E09 US7 - User story 7
Get role by id endpoint.
```{xml} 
Url: /roles/{id}
Type: GET
Response Example:
{
  "name": "Admin",
  "id": "529e960f-79c9-4e25-b3ef-a5ce8cbb42bc"
}
```


### E09 US8 - User story 8
Delete role by id endpoint.
```{xml} 
Url: /roles/{id}
Type: DELETE
```

### E09 US9 - User story 9
Add user endpoint.
```{xml} 
Url: /users
Type: POST
Request Example:
{
  "user": {
    "name": "test"
  },
  "roles": [
    "529e960f-79c9-4e25-b3ef-a5ce8cbb42bc",
    "765f9e20-fb70-4837-8b22-5d280ad9d2d2"
  ],
  "password": "testpassword"
}
```


### E09 US10 - User story 10
Update user endpoint.
```{xml} 
Url: /users
Type: PUT
Request Example:
{
  "user": {
    "id": "9109858d-139b-4a13-a212-c3f6cf4ccc78",
    "name": "Vitalii"
  },
  "roles": [
    "765f9e20-fb70-4837-8b22-5d280ad9d2d2"
  ],
  "password": "updatedpassword"
}
```


### E09 US11 - User story 11
Get user roles endpoint.
```{xml} 
Url: /users/{id}/roles
Type: GET
Response Example:
[
  {
    "name": "Admin",
    "id": "484aeeeb-89d5-4ee7-b8c7-67c7d93292bb"
  },
  {
    "name": "Manager",
    "id": "548d6bec-635b-44ec-b719-baaf32758f12"
  }
]
```

### E09 US12 - User story 12
Get permissions endpoint.
```{xml} 
Url: /roles/permissions
Type: GET
Response Example:
[
  "AddGame",
  "DeleteGame",
  "ViewGame",
  "UpdateGame"
]
```

### E09 US13 - User story 13
Get role permissions endpoint.
```{xml}
Url: /roles/{id}/permissions
Type: GET
Response Example: 
[
  "ViewGame",
  "UpdateGame"
]
```

### E09 US14 - User story 14
Add role endpoint.
```{xml} 
Url: /roles
Type: POST
Request example:
{
  "role": {
    "name": "test role"
  },
  "permissions": [
    "AddGame",
    "ViewGame",
    "UpdateGame"
  ]
}
```


### E09 US15 - User story 15
Update role endpoint.
```{xml}
Url: /roles
Type: PUT
Request example:
{
  "role": {
    "id": "73e12b67-8f8e-4df9-bf0d-f1d7cb7296b4",
    "name": "User"
  },
  "permissions": [
    "ViewGame"
  ]
} 
```

### E09 US16 - User story 16
Get all games without filters endpoint.
```{xml}
Url: /games/all
Type: GET
Response Example:
[
  {
    "id": "92753fa3-0207-4fd3-b892-0fafcb23d429",
    "description": "Test Desc",
    "key": "test1",
    "name": "Test Name",
    "price": 100,
    "discount": 0,
    "unitInStock": 100000
  },
  {
    "id": "12649a00-ca90-4d5e-b088-045db9cf4d9c",
    "description": "Test Desc 2",
    "key": "test2",
    "name": "Test Game2",
    "price": 10,
    "discount": 10,
    "unitInStock": 9000
  }
]
```

### E09 US17 - User story 17
Update order detail quantity endpoint.
```{xml}
Url: /orders/details/{id}/quantity
Type: PATCH
Request Example:
{
  "count": 3
}
```
### E09 US18 - User story 18
Delete order detail endpoint.
```{xml}
Url: /orders/details/{id}
Type: DELETE 
```
### E09 US19 - User story 19
Ship order endpoint.
```{xml}
Url: /orders/{id}/ship
Type: POST 
```

### E09 US20 - User story 20
Add game as the order detail endpoint.
```{xml}
Url: /orders/{id}/details/{key}
Type: POST
```
 
## Optional requirements

**E09 NFR1**  
Implement claim-based authorization. 
**E09 NFR2 [Optional]**
Implement authentication with external microservice.  