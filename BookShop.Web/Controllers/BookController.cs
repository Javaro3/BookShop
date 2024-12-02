using BookShop.Application.Dtos.Book;
using BookShop.Application.Interfaces;
using BookShop.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : BaseController<Book, BookDto, SaveBookDto, BookFilterDto>
{
    public BookController(IDataService<Book, BookDto, SaveBookDto, BookFilterDto> dataService) : base(dataService)
    {
    }
}