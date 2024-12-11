using ChineseSale.Core.Entities;
using ChineseSale.Core.IRepositories;
using ChineseSale.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Service
{
    public class OrderService:IOrderService
    {
        readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAll()
        {
            var dataOrder = _orderRepository.GetAll();
            if (dataOrder == null)
                return null;
            return dataOrder.ToList();
        }
        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }
        public Order Add(Order order)
        {
            if (order == null)
                return null;
            return _orderRepository.Add(order);
        }
        public bool Update(int id, Order order)
        {
            if (order == null)
                return false;
            return _orderRepository.Update(id, order);
        }
        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

    }
}
