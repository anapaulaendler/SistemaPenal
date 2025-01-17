using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class PrisonerProfile : Profile
{
    public PrisonerProfile()
    {
        CreateMap<Prisoner, PrisonerDTO>();
        CreateMap<Prisoner, PrisonerOnlyDTO>();
        CreateMap<Prisoner, PrisonerCreateDTO>();
        CreateMap<Prisoner, PrisonerUpdateDTO>();

        CreateMap<PrisonerDTO, PrisonerCreateDTO>();
        CreateMap<PrisonerDTO, PrisonerUpdateDTO>();
        CreateMap<PrisonerDTO, Prisoner>();

        CreateMap<PrisonerCreateDTO, Prisoner>();

        CreateMap<PrisonerUpdateDTO, Prisoner>();
    }
}