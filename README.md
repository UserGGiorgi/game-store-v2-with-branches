# Game Store Application

## Description

The `GameStore` application is a web-based platform that allows users to browse, purchase, and manage digital games. It provides a seamless shopping experience with various features such as filtering, searching, user authentication, and payment integration. Additionally, the application includes an admin panel for managing game listings, user permissions, and content moderation.

## Application Features

As a result of completing this task, you will receive an application that implements the following features:

- **Game Management**: Admin users can add, edit, and delete game listings.
- **User Authentication and Authorization**: Users can register, log in, and manage their profiles.
- **Search and Filtering**: Users can search for games based on categories, price range, and ratings.
- **Shopping Cart and Checkout**: Customers can add games to their cart and complete purchases using various payment methods.
- **Unit Testing**: The application includes unit tests to ensure functionality and reliability.
- **API Documentation**: Swagger is integrated for clear and structured API documentation.
- **Logging and Error Handling**: The system logs critical events and handles errors effectively.
- **Multi-language Support**: Localization is implemented to support multiple languages.
- **NoSQL Integration**: The application works with multiple databases, including a NoSQL database.
- **Notifications**: Users receive notifications for game updates, promotions, and purchases.
- **UI Design Implementation**: The application follows a structured UI design based on provided mock-ups.
- **Game Reviews and Moderation**: Users can leave reviews and admins can moderate content.
- **Game Image Support**: Each game has an associated image for better user experience.
- **Big Data Processing**: The system is designed to handle large amounts of data efficiently.

## .NET Platform

The task uses the .NET Core CLI command-line tool and references applications that target .NET 8.

Visual Studio 2022 is the most convenient tool to get the task done. However, if your work machine is not configured to run this IDE, development can be done with Visual Studio Code and the .NET Core SDK (or another IDE).

## Branching

The task consists of multiple epics. The description of each epic is in the corresponding `epic-##.md` file in the respective branch.

| Epic | Epic Title | Epic Description | Feature Branch Name              |
|------|-----------|------------------|----------------------------------|
| 1.   | Admin Panel with Services | Implement an admin panel for managing the store. | [game-store-epic-01](epic-01.md) |
| 2.   | Headers and Unit Testing | Implement proper headers and unit tests for API endpoints. | [game-store-epic-02](epic-02.md) |
| 3.   | Logging and Swagger | Add structured logging and API documentation with Swagger. | [game-store-epic-03](epic-03.md) |
| 4.   | Enhancements and UI Integration | Improve UI elements and overall user experience. | [game-store-epic-04](epic-04.md) |
| 5.   | Payment Methods | Extend functionality by adding payment gateway support. | [game-store-epic-05](epic-05.md) |
| 6.   | Comments and Moderation | Add user comments and content moderation features. | [game-store-epic-06](epic-06.md) |
| 7.   | Filters | Implement game filtering and pagination features. | [game-store-epic-07](epic-07.md) |
| 8.   | NoSQL Database | Integrate a NoSQL database alongside the existing relational database. | [game-store-epic-08](epic-08.md) |
| 9.   | Authorization | Implement role-based access control for different user types. | [game-store-epic-09](epic-09.md) |
| 10.  | Game Picture [Microsoft Azure] | Enable game image uploads and display them on game details pages. | [game-store-epic-10](epic-10.md) |
|      | Game Picture [AWS] | Enable game image uploads and display them on game details pages. | [game-store-epic-10-aws](epic-10.md) |
| 11.  | Big Data [Microsoft Azure] | Optimize the system for handling large-scale game data. | [game-store-epic-11](epic-11.md) |
|      | Big Data [AWS]  | Optimize the system for handling large-scale game data. | [game-store-epic-11-aws](epic-11.md) |
| 12.  | Notifications [Microsoft Azure] | Implement user notifications for important events. | [game-store-epic-12](epic-12.md) |
|      | Notifications [AWS]  | Implement user notifications for important events. | [game-store-epic-12-aws](epic-12.md) |
| 13.  | UI Design | Apply UI designs based on given mock-ups. | [game-store-epic-13](epic-13.md) |
| 14.  | Localization | Support multiple languages for the application. | [game-store-epic-14](epic-14.md) |


Each feature is developed in its corresponding branch. Once all features are completed and merged, you will get the final version of the application in the `main` branch.
