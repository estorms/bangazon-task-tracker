# Bangazon-Task-Tracker

## Description

The Bangazon Task Tracker is a simple WebAPI built in .NETCore 1.0. Consumers of the app can use it for the following:

1. Create a new task, with a name, description, status (ToDo, InProgress, Complete), and, when applicable, DateCompleted
1. Change a task's status
1. Search for and filter tasks by status


### Requirements for Use

In order to use the app, the following technologies must be installed on your machine:

* .NET Core [installed](https://www.microsoft.com/net/core#macos).
* [Visual Studio Code](https://code.visualstudio.com/), or [Visual Studio Community Edition](https://www.visualstudio.com/vs/community/) installed for existing Windows users.
* For Code users, [install the C# extension](#installing-c-extension-for-code).
* Yeoman, and the ASP.NET generator, [installed](#installing-yeoman-and-the-aspnet-generator)

Then, fork or clone this respository. Open the code in Visual Studio; then, open the `Package Manager` console and run the following command sequence:


`Add-Migration [-Name]`  
`Update-Database`

Then, run the app. Open your browser of choice and serve the app from URL `localhost://5000/UserTask`; this returns all user tasks.
Tasks are delivered in the following format:
```"userTaskId": 1,
    "name": "Name",
    "description": "Description",
    "status": 0,
    "completedOn": "DateTime"
``` 
1. To retrieve a single task by its Id, send a GET request to localhost://5000/UserTask/{id}
1. To delete a task, send a DELETE request to localhost://5000/UserTask/{id}
1. To edit a task, send a PUT request to localhost://5000/UserTask/{id}
1. To filter tasks by status, query UserTask/ByStatus/{id} Note that int 0 = "To Do"; int 1 = "In Progress"; int 2 = "Completed"

