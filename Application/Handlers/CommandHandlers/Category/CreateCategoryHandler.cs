using Application.Commands.Category;
using Domain.Repositories;
using MediatR;


namespace Application.Handlers.CommandHandlers.Category
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Category name must not be empty or whitespace.");
            }

            var category = new Domain.Entities.Category { Name = request.Name };
            await _repository.AddAsync(category);
            return category.Id;
        }
    }
}
