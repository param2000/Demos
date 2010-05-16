namespace DemoLibrary.Model
{
    public class Order
    {
        public Order(Customer customer)
        {
        }


        public static Order CreateOrder(Customer customer)
        {
            if (customer.IsPreferred)
                return new RushOrder(customer);

            return new Order(customer);
        }
    }

    public class RushOrder :
        Order
    {
        public RushOrder(Customer customer)
            : base(customer)
        {
        }
    }
}