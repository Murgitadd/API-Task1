using APItask1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APItask1.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(GetCategoryDto categoryDto)
        {
            await _repository.AddAsync(new Category
            {
                Name = categoryDto.Name,
            });
        }

        public async Task<ICollection<GetCategoryDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> Categories =await _repository.GetAllAsync(skip:(page-1)*take,take:take,isTracking: false).ToListAsync();



            ICollection<GetCategoryDto> categoryDtos = new List<GetCategoryDto>();
            foreach (var category in Categories)
            {
                categoryDtos.Add(new GetCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return categoryDtos;
        }

        public async Task<GetCategoryDto> GetAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception("NotFound");
            }

            return new GetCategoryDto { Id = category.Id, Name = category.Name };
        }
    }
}
