﻿using ChineseSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.IRepositories
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        Order Add(Order order);
        bool Update(int id, Order order);
        bool Delete(int id);
    }
}