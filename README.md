# MvcProduct
This project followed the Separation of Concerns principle by organizing logic into different components
Controllers handle user interactions.
Services contain the logic for performing addition, subtraction, multiplication and division operations.
Interfaces allow for flexibility and testability.
Models represent data passed between the controller and view.
Views render the user interface using Razor pages.

By separating the program into these different components the code is easier to maintain, test, and extend.
The calculator logic is registered as a transient service using ASP.NET Core’s built-in dependency injection container
