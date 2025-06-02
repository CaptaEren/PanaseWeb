using PanaseWeb.Dtos.PatientJournals;

namespace PanaseWeb.Services.Interfaces
{
    public interface IPatientJournalService : IModelService<JournalEntryCreateDto, JournalEntryResponseDto>
    {
    }
}
