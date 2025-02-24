# Epic 14 - Notifications

Implement user notifications.

## General requirements
Please use the following Angular Front-end: [gamestore-ui-app](gamestore-ui-app) 

System should support the following features: 
* Multiple notification methods.
* Order status notifications.
   

## Additional requirements
#### Notifications source
	Managers and order owner get notifications on every order status change.
#### Notification methods
	There are three notification methods: SMS (should be faked for now), push notification (should be faked for now), and email (should be implemented)
#### Preferred notification methods
	Users can select preferable notification methods. 	


## Task Description

### E14 US1 - User story 1

Get notification methods endpoint.
```{xml} 
Url: /users/notifications
Type: GET
Response example:
[
  "sms",
  "push",
  "email"
]
```

### E14 US2 - User story 2
Get user selected notification methods endpoint.
```{xml} 
Url: /users/my/notifications
Type: GET
Response example:
[
  "push",
  "email"
]
```

### E14 US3 - User story 3
Update user selected notification methods endpoint.
```{xml} 
Url: /users/notifications
Type: PUT
Request Example:
{
  "notifications": [
    "sms",
    "email"
  ]
}
```


### E14 US4 - User story 4

Implement email notification infrastructure.

## Non-functional requirement (Optional)

**E14 NFR1**
Use Azure Service Bus as part of email infrastructure. 