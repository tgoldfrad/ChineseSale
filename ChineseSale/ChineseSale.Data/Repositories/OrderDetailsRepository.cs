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
    public class OrderDetailsRepository:IOrderDetailsRepository
    {
        readonly DataContext _dataContext;
        public OrderDetailsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<OrderDetails> GetAll()
        {
            return _dataContext.OrderDetailsList.ToList();
        }
        public OrderDetails GetById(int id)
        {
            return _dataContext.OrderDetailsList.Where(o => o.OrderDetailId == id).FirstOrDefault();
        }
        public OrderDetails Add(OrderDetails orderDetails)
        {
            try
            {
                _dataContext.OrderDetailsList.Add(orderDetails);
                _dataContext.SaveChanges();
                return orderDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, OrderDetails orderDetails)
        {
            var orderDetailsToUpdate = _dataContext.OrderDetailsList.Find(id);
            if(orderDetailsToUpdate == null)
                return false;

            orderDetailsToUpdate.Amount = orderDetails.Amount > 0 ? orderDetails.Amount : orderDetailsToUpdate.Amount;
            orderDetailsToUpdate.FinalPayment = orderDetails.FinalPayment > 0 ? orderDetails.FinalPayment : orderDetailsToUpdate.FinalPayment;
            _dataContext.SaveChanges();
            return true;

        }
        public bool Delete(int id)
        {
            var orderDetailsToDelete = GetById(id);
            if (orderDetailsToDelete == null)
                return false;
            _dataContext.OrderDetailsList.Remove(orderDetailsToDelete);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
