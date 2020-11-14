using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weblab2.Domain.Entities;

namespace weblab2.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldByID(Guid id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid id);
    }
}
