using AutoMapper;
using BlazorUpdateTest.Entities.Books;
using BlazorUpdateTest.Services.Dtos.Books;

namespace BlazorUpdateTest.ObjectMapping;

public class BlazorUpdateTestAutoMapperProfile : Profile
{
    public BlazorUpdateTestAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<BookDto, CreateUpdateBookDto>();
        /* Create your AutoMapper object mappings here */
    }
}
