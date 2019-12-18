using CarServiceSystem.src.entity;
using CarServiceSystem.src.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceSystem.src.service
{
    internal interface IClientService : ICrudService<Client, Guid>
    {
        void Delete(Client client);
        List<Client> GetByFilter(FilterClient filter);
    }
}
