using CarServiceSystem.src.entity;
using CarServiceSystem.src.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceSystem.src.service
{
    class OrderRepairServiceImpl : IOrderRepairService
    {
        private static readonly IOrderRepairService orderService = new OrderRepairServiceImpl();
        private readonly Context context;

        public OrderRepairServiceImpl() => context = new Context();

        public static IOrderRepairService GetService() => orderService;

        public OrderRepair Create(OrderRepair entity)
        {
            context.OrderRepair.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public OrderRepair GetById(Guid id)
        {
            return context.OrderRepair.FirstOrDefault(c => c.Id.Equals(id));
        }

        public OrderRepair Update(OrderRepair entity)
        {
            context.OrderRepair.Add(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
