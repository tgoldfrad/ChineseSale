using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class OrdersServer
    {
        //public List<Orders> orders=new List<Orders>()
        //{
        //    new Orders(){OrderId=1,DonorId=1,OrderDate=new DateTime(12,09,2024),OrderFinalPayment=300,IsTaxReceipt=false,NameReceipt="",PaymentIsOrdered=true,Remarks="OK"}
        //};
        public List<Orders> GetOrders()
        {
            return DataContextManager.DataContext.OrdersList;
        }
        public Orders GetOrdersById(int id)
        {
            return DataContextManager.DataContext.OrdersList.Find(x => x.OrderId == id);
        }
        public bool AddOrders(Orders order)
        {
            DataContextManager.DataContext.OrdersList.Add(order);
            return true;
        }
        public bool UpdateOrders(int id,Orders order)
        {
            int index = DataContextManager.DataContext.OrdersList.FindIndex(x => x.OrderId == id);
            if(index != -1)
            {
                DataContextManager.DataContext.OrdersList[index]=order;
                return true;
            }
            return false;

        }
        public bool DeleteOrders(int id)
        {
            Orders order=GetOrdersById(id);
            if(order!=null)
            {
                DataContextManager.DataContext.OrdersList.Remove(order);
                return true;
            }
            return false;
        }
    }
}
