using CarServiceSystem.src.entity;
using CarServiceSystem.src.util;
using System;
using System.Collections.Generic;

namespace CarServiceSystem.src.service
{
    internal interface ICarClientService : ICrudService<CarClient, Guid>
    {
        List<CarClient> GetAll();
    }
}
