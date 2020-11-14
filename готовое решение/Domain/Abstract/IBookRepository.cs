using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    //используем для получения сущностей из Book
    public interface IBookRepository
    {
        //используем этот интерфейс, чтобы позволить всплывающему коду
        //получать последовательность объектов Book, ничего не сообщая о том, как или где извлекаются данные
        IEnumerable<Book> Books { get; }
    }
}
