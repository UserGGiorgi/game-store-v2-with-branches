# Epic 6 - Comments and Moderation
Extend functionality by adding comments, quotations, and moderation features. 

## General requirements
Please use the following Angular Front-end: [gamestore-ui-app](gamestore-ui-app)

System should support the following features: 
* Add comments to the game.
* Get Game comments.
* Delete comment.
* Ban user for selected duration.
* Reply comment.
* Quote comment.


### Entities
**Comment**  
* **Id:** Guid, required, unique
* **Name:** String, required
* **Body:** String, required
* **ParentCommentId:** Guid, optional
* **GameId:** Guid, required

## Additional Requirements
#### Comments hierarchy
	Comments reply depth is unlimited.


#### Comment reply
	The reply should have the following format “[Author], Text of Reply“, where: “[Author]” – Name of the author of a parent comment.


#### Comment quote
	Quote works like the Reply, but automatically adds text from the parent comment. Quote format is following 	“[Body], Text of Quote“, where: “[Body]” – Content of the parent comment.


#### Deleted Comment
	The message ''A comment/quote was deleted'' should be shown after comment deletion instead of the original body. 	All comments that quote a deleted comment must also contain the text ''A comment/quote was deleted'' instead of deleted comment text.


#### Ban:
	Banned users cannot add game comments.
	Ban durations: 1 hour, 1 day, 1 week, 1 month, permanent.
	We don’t have users, so implement ban by name for now.

## Task Description

### E06 US1 - User story 1

Add Comment by game key endpoint


```{xml} 
Url: /games/{key}/comments
Type: POST
Validation: All comment fields are required 
Request Example:
{
  "comment": {
    "name": "My Name",
    "body": "Awesome comment text"
  },
  "parentId": null,
  "action": null
}
```

### E06 US2 - User story 2
Get all comments by game key endpoint.
```{xml} 
Url: /games/{key}/comments
Type: GET 
Response example:
[
  {
    "id": "55d8e87f-3710-40d1-88ed-257594ebadaa",
    "name": "My Name",
    "body": "Test comment ",
    "childComments": [
      {
        "id": "f2e4b854-14b2-4075-b6ab-18fc29341a27",
        "name": "Another NAme",
        "body": "Another Comment",
        "childComments": []
      }
    ]
  },
  {
    "id": "bfcbf906-0cc7-4321-8854-a0c88baa9e07",
    "name": "My Name",
    "body": "Second comment",
    "childComments": []
  }
]
```

### E06 US3 - User story 3
Delete comment endpoint
```{xml} 
Url: /games/{key}/comments/{id}
Type: DELETE
```


### E06 US4 - User story 4
Get Ban duration options endpoint.  
```{xml} 
Url: /comments/ban/durations
Type: GET
Response Example:
[
  "1 hour",
  "1 day",
  "1 week",
  "1 month",
  "permanent"
]
```

### E06 US5 - User story 5
Ban user by name endpoint.
```{xml} 
Url: /comments/ban
Type: POST
Request Example:
{
  "user": "test",
  "duration": "1 month"
}
```