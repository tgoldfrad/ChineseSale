using ChineseSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.IServices
{
    public interface IOrderDetailsService
    {
        List<OrderDetails> GetAll();
        OrderDetails GetById(int id);
        OrderDetails Add(OrderDetails orderDetails);
        bool Update(int id, OrderDetails orderDetails);
        bool Delete(int id);
    }
}
