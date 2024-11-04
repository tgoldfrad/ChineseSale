using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class OrdersServer
    {
        public List<Orders> orders=new List<Orders>()
        {
            new Orders(){OrderId=1,DonorId=1,OrderDate=new DateTime(12,09,2024),OrderFinalPayment=300,IsTaxReceipt=false,NameReceipt="",PaymentIsOrdered=true,Remarks="OK"}
        };
        public List<Orders> GetOrders()
        {
            return orders;
        }
        public Orders GetOrdersById(int id)
        {
            return orders.Find(x => x.OrderId == id);
        }
        public bool PostOrders(Orders order)
        {
            orders.Add(order);
            return true;
        }
        public bool PutOrders(int id,Orders order)
        {
            int index = orders.FindIndex(x => x.OrderId == id);
            if(index != -1)
            {
                orders[index]=order;
                return true;
            }
            return false;

        }
        public bool DeleteOrders(int id)
        {
            Orders order=orders.Find(x => x.OrderId == id);
            if(order!=null)
            {
                orders.Remove(order);
                return true;
            }
            return false;
        }
    }
}
