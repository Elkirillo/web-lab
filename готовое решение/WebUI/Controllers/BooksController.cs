using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repository;
        //количество товаров, отображаемых на странице
        public int pageSize = 4;

        //этот конструктор, который объявляет зависимость от IBookRepository
        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View();
        }
      
        public ViewResult List(string genre, int page = 1)
        {
            
            BooksListViewModel model = new BooksListViewModel
            {
                Books = repository.Books
                .Where(b => genre == null || b.Genre == genre)
                .OrderBy(book => book.BookId)//отображем книги по первичному ключу
                .Skip((page - 1) * pageSize)//пропускаем книги, которые расположены до начала текущей страницы
                .Take(pageSize),//выбираем количество товаров, которое указывали ранее
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    //для корректного вывода книг в категориях
                    TotalItems = genre == null ? 
                        repository.Books.Count() : 
                        repository.Books.Where(book => book.Genre == genre).Count()
                },
                CurrentGenre = genre
            };
            
            return View(model);
        }
    }
}