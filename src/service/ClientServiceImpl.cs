using CarServiceSystem.src.entity;
using CarServiceSystem.src.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CarServiceSystem.src.service
{
    class ClientServiceImpl : IClientService
    {
        private static readonly IClientService service = new ClientServiceImpl();
        private readonly Context context;

        public ClientServiceImpl() => context = new Context();

        public static IClientService GetService() => service;

        public Client Create(Client entity)
        {
            context.Client.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Client> GetByFilter(FilterClient filter)
        {
            IQueryable<Client> query = context.Client
                .Include(c => c.CarClientList)
                .Include(c => c.OrderRepairList);
            if (filter.FirstName != "")
            {
                query = query.Where(c => c.FirstName.Contains(filter.FirstName));
            }
            if (filter.MiddleName != "")
            {
                query = query.Where(c => c.MiddleName.Contains(filter.MiddleName));
            }
            if (filter.LastName != "")
            {
                query = query.Where(c => c.LastName.Contains(filter.LastName));
            }
            if (filter.Inn != null && filter.Inn != 0)
            {
                query = query.Where(c => c.Inn.ToString().Contains(filter.Inn.ToString()));
            }
            return query.ToList();
        }

        public Client GetById(Guid id)
        {
            return context.Client
                .Include(c => c.CarClientList)
                .Include(c => c.OrderRepairList)
                .FirstOrDefault(c => c.Id.Equals(id));
        }

        public Client Update(Client entity)
        {
            context.SaveChanges();
            return entity;
        }
    }
}
