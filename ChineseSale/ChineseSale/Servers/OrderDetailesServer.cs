using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class OrderDetailesServer
    {
        //public List<OrderDetailes> orderDetailes=new List<OrderDetailes>()
        //{
        //    new OrderDetailes(){OrderDetailId=1,OrderId=1,ProductId=2,amount=2,finalPayment=80}
        //};
        public List<OrderDetailes> GetOrderDetailes()
        {
            return DataContextManager.DataContext.OrderDetailesList;
        }
        public OrderDetailes GetOrderDetailesById(int id)
        {
            return DataContextManager.DataContext.OrderDetailesList.Find(x => x.OrderDetailId == id);
        }
        public bool AddOrderDetailes(OrderDetailes o)
        {
            DataContextManager.DataContext.OrderDetailesList.Add(o);
            return true;
        }
        public bool UpdateOrderDetailes(int id,OrderDetailes o)
        {
            int index = DataContextManager.DataContext.OrderDetailesList.FindIndex(x => x.OrderDetailId == id);
            if(index!=-1)
            {
                DataContextManager.DataContext.OrderDetailesList[index] = o;
                return true;
            }
            return false;
                
        }
        public bool DeleteOrderDetailes(int id)
        {
            OrderDetailes o = GetOrderDetailesById(id);
            if(o!=null)
            {
                DataContextManager.DataContext.OrderDetailesList.Remove(o);
                return true;
            }
            return false;
        }
    }
}
