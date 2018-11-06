# Catmash

An application to find the cutest cat

## Application Structure

    Business/       # Contains Models and data access classes
    Serices/        # The layer between the user interactions and the Business layer
    Core/           # Holds methods useful to the application
    Tests/          # Unit Tests for methods across the application
    Web/            # Contains the Views and Controllers

#### Business/

This folder contains the application's global Models, and the access to the database using the ADO.Net EntityFramework Code-First approch.

>To add a Table in the database, the following directory structure is recommended:
```shell
Add a class (which will represent the table) in `Model/`
Add a DbSet entity of this class in `Context/RatingContext`
```

When application is lunched it checks if the database exists, if no it creates a new one and add data from the url

#### Core/

    Core/
      /Extensions     #Contains Extensions that can be usefull in the whole project
      /Json           #The json deserializer to read json into an object 
      /RatingSystem	  #Methods that calculate the rating between two given scores


#### Services/

Methods that play a role of a gateway between business layer and other layers in the application

#### Tests/

Unit Test on the methods declared across the application

#### Web/

The Web application, it contains the Views and Controllers.
