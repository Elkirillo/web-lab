using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using weblab2.Domain.Entities;
using weblab2.Domain.Repositories.Abstract;

namespace weblab2.Domain.Repositories.EntityFramework
{
    public class EFServiceItemRepository : IServiceItemRepository
    {
        private readonly AppDbContext context;
        public EFServiceItemRepository (AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Serviceitem> GetServiceitems()
        {
            return context.Serviceitems;
        }

        public Serviceitem GetServiceitemById(Guid id)
        {
            return context.Serviceitems.FirstOrDefault(x => x.Id == id);
        }
        public void SaveServiceitem(Serviceitem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteServiceitem(Guid id)
        {
            context.Serviceitems.Remove(new Serviceitem() { Id = id });
            context.SaveChanges();
        }
    }
}
