# Epic 2 - Headers and Unit Testing

## Before you started

You can find `project configuration requerarments` in [this](AdditionalInfo/project-configuration.md) file and the `git workflow instructions` in [this](AdditionalInfo/git-workflow-instructions.md) one.

## General requirements

System should support the following features: 
* Total Games count calculation.    

Technical specifications:
* Code coverage rate must be not lower than 50%.  
* Use Moq package for test data mocks.  
* Use XUnit package for unit tests.  

### E02 US1 - User story 1

Add x-total-numbers-of-games response header which represents the total games count in the system.
A header should be added in each API response.
Hint: The header should be exposed in Cors’s configuration.
Example:
```{xml} 
 content-type: application/json; charset=utf-8 
 date: Fri,17 Nov 2023 18:21:31 GMT 
 server: Kestrel 
 x-total-numbers-of-games: 4 
```

### E02 US2 \[Optional\]
x-total-numbers-of-games header value should be cached for 1 minute



 
## Non-functional requirement (Optional)

**E02 NFR1**
Cover application code with by Unit tests with coverage not lower than 50%.   