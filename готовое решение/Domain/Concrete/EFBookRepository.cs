using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    //реализует интерфейс и является хранилищем наших товаров
    public class EFBookRepository : IBookRepository
    {
        //использует экземпляры EFDbContext для извлечения данных из нашей бд
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get { return context.Books; }
        }
    }
}
