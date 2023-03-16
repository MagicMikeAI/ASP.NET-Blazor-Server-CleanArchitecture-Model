# # Clean Architecture Blazor Server Example

This example demonstrates a Blazor Server application that follows Clean Architecture principles. It's a simple Todo application that allows users to create and retrieve Todo items.

## Overview

The solution is divided into the following projects:

- Domain
- Application
- Infrastructure
- UI

Each layer has its own responsibilities and communicates with other layers through well-defined interfaces.

## Application Flow

Here's the flow of the application when creating and retrieving Todo items:

1. **User Interaction**: The user interacts with the UI components in the Blazor Server application to perform actions like creating a new Todo item or viewing a list of Todo items.

2. **UI Layer**: The UI components call the `ITodoService` methods to perform the desired actions (e.g., `AddAsync`, `GetAllAsync`). The `ITodoService` instance is provided to the UI components through dependency injection.

3. **Application Layer**: The `TodoService` class, which implements the `ITodoService` interface, receives the calls from the UI layer. This class contains the business logic and is responsible for coordinating tasks and delegating work to the appropriate components. In the case of creating or retrieving Todo items, the `TodoService` class will delegate the work to the `ITodoItemRepository` by calling its methods (e.g., `AddAsync`, `GetAllAsync`). The `ITodoItemRepository` instance is provided to the `TodoService` through dependency injection.

4. **Domain Layer**: The `ITodoItemRepository` interface represents the contract for the data access operations related to the `TodoItem` entity. The actual implementation of the repository is in the Infrastructure layer, but the domain layer defines the methods that should be available for the data access operations.

5. **Infrastructure Layer**: The `TodoItemRepository` class, which implements the `ITodoItemRepository` interface, is responsible for the actual data access operations using Entity Framework Core. When a method is called on the `TodoItemRepository` instance, it interacts with the `ApplicationDbContext` to perform the desired data operation, such as adding a new Todo item to the database or retrieving a list of Todo items.

6. **Database**: The `ApplicationDbContext` communicates with the database using the connection string specified in the `appsettings.json` file. The database is updated or queried based on the operations performed by the `TodoItemRepository`.

7. **Back to the UI**: Once the data operation is complete, the results (if any) are passed back up the chain from the Infrastructure layer to the Application layer, and finally to the UI layer, where the data is displayed or the UI is updated based on the action performed.

This flow demonstrates how each layer of the Clean Architecture implementation is responsible for specific tasks and communicates with other layers through well-defined interfaces. This separation of concerns ensures that each layer can evolve independently and promotes maintainability and testability.


## Extensibility and Advanced Concepts

This example demonstrates the basic concepts of Clean Architecture, focusing on the separation of concerns between the different layers and the use of well-defined interfaces for communication between them. However, Clean Architecture can be extended to include more advanced concepts, such as:

1. **Domain Events**: Implementing a domain event system to handle cross-cutting concerns and promote decoupling between different parts of the application.
2. **CQRS (Command Query Responsibility Segregation)**: Separating read and write operations to further decouple the application and optimize performance, particularly in scenarios with complex business logic and large-scale data operations.
3. **Mediator Pattern**: Using a mediator library like MediatR to simplify communication between components and promote loose coupling, making it easier to maintain and test the application.
4. **Validation**: Implementing validation mechanisms at different layers, such as using FluentValidation to validate input data and applying domain-specific validation rules in the Domain layer.
5. **Unit and Integration Testing**: Writing unit and integration tests for the different layers of the application to ensure its correctness and stability during development and maintenance.

## Using MediatR for Command and Query Handling

The application has been updated to use MediatR, a popular library for implementing the Mediator pattern, to handle commands and queries. This new approach promotes loose coupling and makes the application more maintainable and easier to test. Here's a summary of how MediatR is integrated into the application:

1. **UI Layer**: The UI components now send commands and queries to the Application layer using the `IMediator` interface. The `IMediator` instance is provided to the UI components through dependency injection.

2. **Commands and Queries**: Commands and queries are simple classes that encapsulate the input data and the desired operation. They are defined in the Application layer and are handled by corresponding command and query handlers.

3. **Command and Query Handlers**: The handlers are classes that implement the `IRequestHandler` interface from MediatR. They are responsible for handling a specific command or query and contain the necessary logic to perform the operation. The handlers are located in the Application layer and use the `ITodoItemRepository` to interact with the Domain and Infrastructure layers.

4. **MediatR Registration**: MediatR is registered in the `Program.cs` file of the UI project. The `AddMediatR` extension method is used to scan the Application assembly for defined command and query handlers, and it automatically registers them with the dependency injection container.

The following code snippet shows an example of a command, a query, and their respective handlers:

```csharp
// A command to create a new Todo item
public record CreateTodoItemCommand(TodoItem TodoItem) : IRequest<Guid>;

// The handler for the CreateTodoItemCommand
public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
{
    private readonly ITodoItemRepository _repository;

    public CreateTodoItemCommandHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(request.TodoItem);
        return request.TodoItem.Id;
    }
}

// A query to get all Todo items
public record GetAllTodoItemsQuery() : IRequest<IEnumerable<TodoItem>>;

// The handler for the GetAllTodoItemsQuery
public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
{
    private readonly ITodoItemRepository _repository;

    public GetAllTodoItemsQueryHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
```

By using MediatR and the command/query pattern, the application's architecture is more organized and maintainable. Each command and query is self-contained and focused on a single responsibility, making it easier to understand the flow of data and logic within the application.


## New Features Added

The original implementation has been extended to include the following features:

1. Categories: Todo items can now be associated with categories.
2. Category Management: Users can create and manage categories through the UI.
3. Todo Items with Categories: The list of Todo items now displays the associated category for each item.

## Changes and Additions to the Architecture

To accommodate these new features, the following changes and additions have been made to the architecture:

1. **Domain Layer**: A new `Category` entity has been added to the Domain layer, representing a category that can be associated with a Todo item. The `TodoItem` entity has been updated to include a `CategoryId` property and a navigation property for the associated `Category` entity.

2. **Application Layer**: The Application layer has been updated to include new commands and queries for category management, such as `CreateCategoryCommand`, `GetAllCategoriesQuery`, and their respective handlers. The `GetAllTodoItemsQuery` has been extended to retrieve Todo items with their associated categories.

3. **Infrastructure Layer**: A new `ICategoryRepository` interface has been added to the Domain layer to define the contract for category data access operations. The Infrastructure layer now includes an implementation of this interface, `CategoryRepository`, which performs data access operations for the `Category` entity using Entity Framework Core.

4. **UI Layer**: The UI layer has been updated to include new components for category management, such as `CreateCategory.razor` and `CategoryList.razor`. The `TodoItems.razor` component has been modified to display the associated category for each Todo item and to allow users to select a category when creating a new Todo item.

