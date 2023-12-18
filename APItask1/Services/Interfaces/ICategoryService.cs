namespace APItask1.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<GetCategoryDto>> GetAllAsync(int page, int take);
        Task<GetCategoryDto> GetAsync(int id);
        Task CreateAsync(CreateCategoryDto categoryDto);
    }
}
