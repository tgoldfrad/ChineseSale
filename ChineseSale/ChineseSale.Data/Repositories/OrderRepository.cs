using ChineseSale.Core.Entities;
using ChineseSale.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Data.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        readonly DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Order> GetAll()
        {
            return _dataContext.OrdersList.ToList();
        }
        public Order GetById(int id)
        {
            return _dataContext.OrdersList.Where(o => o.OrderId == id).FirstOrDefault();
        }
        public Order Add(Order order)
        {
            try
            {
                _dataContext.OrdersList.Add(order);
                _dataContext.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, Order order)
        {
            var orderToUpdate = _dataContext.OrdersList.Find(id);
            if(orderToUpdate == null)
                return false;

            orderToUpdate.OrderDate = order.OrderDate != null ? order.OrderDate : orderToUpdate.OrderDate;
            orderToUpdate.PaymentIsOrdered = order.PaymentIsOrdered;
            orderToUpdate.IsTaxReceipt = order.IsTaxReceipt;//לבדוק מה קורה  עם בול
            orderToUpdate.NameReceipt = !String.IsNullOrEmpty(order.NameReceipt) ? order.NameReceipt : orderToUpdate.NameReceipt;
            orderToUpdate.OrderFinalPayment = order.OrderFinalPayment > 0 ? order.OrderFinalPayment : orderToUpdate.OrderFinalPayment;
            orderToUpdate.Remarks = !String.IsNullOrEmpty(order.Remarks) ? order.Remarks : orderToUpdate.Remarks;

            _dataContext.SaveChanges();
            return true;

        }
        public bool Delete(int id)
        {
            var orderToDelete = GetById(id);
            if (orderToDelete == null)
                return false;
            _dataContext.OrdersList.Remove(orderToDelete);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
