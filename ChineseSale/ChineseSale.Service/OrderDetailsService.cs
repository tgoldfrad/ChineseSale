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
    public class OrderDetailsService:IOrderDetailsService
    {
        readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public List<OrderDetails> GetAll()
        {
            var dataOrderDetails = _orderDetailsRepository.GetAll();
            if (dataOrderDetails == null)
                return null;
            return dataOrderDetails.ToList();
        }
        public OrderDetails GetById(int id)
        {
            return _orderDetailsRepository.GetById(id);
        }
        public OrderDetails Add(OrderDetails orderDetails)
        {
            if (orderDetails == null)
                return null;
            return _orderDetailsRepository.Add(orderDetails);
        }
        public bool Update(int id, OrderDetails orderDetails)
        {
            if (orderDetails == null)
                return false;
            return _orderDetailsRepository.Update(id, orderDetails);
        }
        public bool Delete(int id)
        {
            return _orderDetailsRepository.Delete(id);
        }
    }
}
