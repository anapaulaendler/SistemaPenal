using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDTO>();
        CreateMap<Book, BookCreateDTO>();
        
        CreateMap<BookDTO, BookCreateDTO>();
        CreateMap<BookDTO, Book>();

        CreateMap<BookCreateDTO, Book>();
    }
}