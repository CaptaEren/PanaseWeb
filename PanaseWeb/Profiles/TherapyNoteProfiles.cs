using AutoMapper;
using PanaseWeb.Dtos.TherapyNotes;
using PanaseWeb.Models;

namespace PanaseWeb.Profiles
{
    public class TherapyNoteProfiles : Profile
    {
        public TherapyNoteProfiles()
        {
            CreateMap<TherapyNote, TherapyNoteResponseDto>();
            CreateMap<TherapyNoteCreateDto, TherapyNote>();
        }
    }
}