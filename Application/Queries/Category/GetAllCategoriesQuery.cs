using Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Category
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
