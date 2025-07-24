# Epic 7 - Filters
Extend the functionality of the Online Game Store by adding filtering and pagination features.

## General requirements
Please use the following Angular Front-end: [gamestore-ui-app](gamestore-ui-app)

System should support the following features: 
* Games filtration
* Games pagination
* Games sorting

## Additional Requirements
#### Filtration
	Filtration by the next options is possible:
	Genres: multiple select.
	Platforms: multiple select.
	Publishers: multiple select.
	Price range: min and max inputs, if one of the values is not populated, should be treated as an unlimited.
	Publishing date: single select.
	Name: text input. 


#### Publish date filtration
	Filtering by time range when a game was created.
	Possible options: last week, last month, last year, 2 years, 3 years.


#### Game name filtration
	Filtering by Any part of a name but at least 3 chars are required to start filtration by Game Name.


#### Filter combinations
	If multiple values of the same filter are selected (for example two genres are selected) these should be treated as OR statements (return games which belong to 1 or genre 2).
	If multiple filters are selected (for example some genres and some platforms are selected) these should be treated as AND statements (return games that belong to at least one from selected genres and at least one from selected platforms).


#### Sorting 
	Sorting by the next options is possible:
	Most popular: most viewed games are on the top.
	Most commented: games with the largest number of comments are on the top.
	Price ASC: cheapest games are on the top.
	Price DESC: most expensive games are on the top.
	New: most recently created games are on the top.


#### Pagination
	The next numbers of games per page are available: 10, 20, 50, 100, all.


## Task Description

### E07 US1 - User story 1

Get pagination options endpoint.
```{xml} 
Url:  /games/pagination-options
Type: GET
Response Example:
[
  "10",
  "20",
  "50",
  "100",
  "all"
]
```

### E07 US2 - User story 2
Get sorting options endpoint.
```{xml} 
Url: /games/sorting-options
Type: GET
Response Example:
[
  "Most popular",
  "Most commented",
  "Price ASC",
  "Price DESC",
  "New"
]
```

### E07 US3 - User story 3
Get the publish date filter options endpoint.
```{xml} 
Type: GET
Response example:
[
  "last week",
  "last month",
  "last year",
  "2 years",
  "3 years"
]
```


### E07 US4 - User story 4

Get games endpoint should be updated to support filters in the query.
 
```{xml} 
Url: /games
Type: GET
Response example: 
{
  "games": [
    {
      "id": "8865d113-830c-49c7-bfad-9f9d2d47f103",
      "description": "",
      "key": "Name_2",
      "name": "Name 2",
      "price": 1000,
      "discount": 1,
      "unitInStock": 11
    },
    {
      "id": "0d86dd4f-265d-407b-848b-76cb82a4ce38",
      "description": "",
      "key": "Name_3",
      "name": "Name 3",
      "price": 13415,
      "discount": 223,
      "unitInStock": 143
    }
  ],
  "totalPages": 5,
  "currentPage": 2
}  
```


## Non-functional requirement

**E07 NFR1**  
Add functionality to count the number of views of the Game page.  

**E07 NFR2**  
Use pipeline pattern to implement filtration\sorting\pagination logic.
