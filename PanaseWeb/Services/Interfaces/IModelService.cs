namespace PanaseWeb.Services.Interfaces
{
    public interface IModelService<TCreateDto, TResponseDto>
    {
        Task<IEnumerable<TResponseDto>> GetAllAsync();
        Task<TResponseDto?> GetByIdAsync(int id);
        Task<TResponseDto> CreateAsync(TCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
