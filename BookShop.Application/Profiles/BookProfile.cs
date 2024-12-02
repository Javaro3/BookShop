using AutoMapper;
using BookShop.Application.Dtos.Book;
using BookShop.Domains.Entities;

namespace BookShop.Application.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();

        CreateMap<Book, SaveBookDto>();
        CreateMap<SaveBookDto, Book>();
    }
}