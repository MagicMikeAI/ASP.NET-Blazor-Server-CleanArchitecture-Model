using Application.DTOs.Category;
using Application.Queries.Category;
using Domain.Repositories;
using MediatR;


namespace Application.Handlers.QueryHandlers.Category
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
