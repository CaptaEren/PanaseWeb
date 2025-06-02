using PanaseWeb.Dtos.Psychologists;

namespace PanaseWeb.Services.Interfaces
{
    public interface IPsychologistService : IModelService<PsychologistCreateDto, PsychologistResponseDto>
    {
        Task<bool> UpdateAsync(int id, PsychologistUpdateDto dto);
        Task<PsychologistDetailDto?> GetDetailByIdAsync(int id);
    }
}
