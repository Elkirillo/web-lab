using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weblab2.Domain.Repositories.Abstract;

namespace weblab2.Domain
{
    //класс для управления репозитория
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemRepository ServiceItem { get; set; }
        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemRepository serviceItemRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItem = serviceItemRepository;
        }
    }
}
