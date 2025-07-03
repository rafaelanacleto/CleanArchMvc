using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int? Id { get; set; }

        public GetCategoryByIdQuery(int? id)
        {
            Id = id;
        }

        // Additional properties or methods can be added here if needed
        // This class is used to query a category by its Id.
        // It implements IRequest<Category> to return a Category object.
        // The MediatR library will handle the request and return the appropriate category.
        // This class can be used in a CQRS pattern to separate the query logic from the
        // command logic, allowing for better organization and maintainability of the codebase.
        // It can be used in conjunction with a handler that processes the query and retrieves
        // the category from a data source, such as a database or an in-memory collection.
        // The handler will implement the logic to fetch the category based on the provided Id.
        // This approach promotes a clean architecture by separating concerns and allowing for
        // easier testing and scalability of the application.
        // The GetCategoryByIdQuery class can be used in a controller or service to handle
        // requests for retrieving a specific category by its Id.
        // It can be injected into a MediatR pipeline to handle the request and return the
    }
}