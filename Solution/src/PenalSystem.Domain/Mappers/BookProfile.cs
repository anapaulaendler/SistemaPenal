using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class BookProfile
{
    public BookProfile()
    {
        Mapper.CreateMap<Book, BookDTO>();
    }
}