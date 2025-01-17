using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class StudyProfile : Profile
{
    public StudyProfile()
    {
        CreateMap<Study, StudyDTO>();
        CreateMap<Study, StudyCreateDTO>();

        CreateMap<StudyDTO, StudyCreateDTO>();
        CreateMap<StudyDTO, Study>();

        CreateMap<StudyCreateDTO, Study>();
    }
}