using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weblab2.Domain.Entities;

namespace weblab2.Domain.Repositories.Abstract
{
    public interface IServiceItemRepository
    {
        IQueryable<Serviceitem> GetServiceitems();
        Serviceitem GetServiceitemById(Guid id);

        void SaveServiceitem(Serviceitem entity);
        void DeleteServiceitem(Guid id);
    }
}
