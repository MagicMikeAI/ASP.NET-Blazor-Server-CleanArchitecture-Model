using Application.Commands.Category;
using Application.DTOs.Category;
using Application.Interfaces;
using Application.Queries.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;

        public CategoryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery(id));
        }


        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllCategoriesQuery());
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            Guid newCategoryId = await _mediator.Send(new CreateCategoryCommand(createCategoryDto.Name));

            var newCategoryDto = new CategoryDto
            {
                Id = newCategoryId,
                Name = createCategoryDto.Name
            };

            return newCategoryDto;
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _mediator.Send(new UpdateCategoryCommand(updateCategoryDto.Id, updateCategoryDto.Name));
        }


        public async Task DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));
        }
    }
}
