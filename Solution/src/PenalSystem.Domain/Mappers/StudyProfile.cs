using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class StudyProfile
{
    public StudyProfile()
    {
        Mapper.CreateMap<Study, StudyDTO>();
    }
}