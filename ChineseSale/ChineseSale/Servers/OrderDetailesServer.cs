using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class OrderDetailesServer
    {
        public List<OrderDetailes> orderDetailes=new List<OrderDetailes>()
        {
            new OrderDetailes(){OrderDetailId=1,OrderId=1,ProductId=2,amount=2,finalPayment=80}
        };
        public List<OrderDetailes> GetOrderDetailes()
        {
            return orderDetailes;
        }
        public OrderDetailes GetOrderDetailesById(int id)
        {
            return orderDetailes.Find(x => x.OrderDetailId == id);
        }
        public bool PostOrderDetailes(OrderDetailes o)
        {
            orderDetailes.Add(o);
            return true;
        }
        public bool PutOrderDetailes(int id,OrderDetailes o)
        {
            int index = orderDetailes.FindIndex(x => x.OrderDetailId == id);
            if(index!=-1)
            {
                orderDetailes[index] = o;
                return true;
            }
            return false;
                
        }
        public bool DeleteOrderDetailes(int id)
        {
            OrderDetailes o = orderDetailes.Find(x => x.OrderDetailId == id);
            if(o!=null)
            {
                orderDetailes.Remove(o);
                return true;
            }
            return false;
        }
    }
}
