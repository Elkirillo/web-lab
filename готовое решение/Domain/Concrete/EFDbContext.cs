using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    //используем этот класс контекст для свзяки ef фреймворка с нашей базой данных
    public class EFDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
