using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class PrisonerProfile
{
    public PrisonerProfile()
    {
        Mapper.CreateMap<Prisoner, PrisonerDTO>();
    }
}