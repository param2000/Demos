namespace Creation1
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using DemoLibrary.Model;

    internal class Program
    {
        private static void Main(string[] args)
        {

            var customer = new Customer
                {
                    IsPreferred = true
                };

            var order = Order.CreateOrder(customer);

            // the problem is this logic needs to be in one place, since we may have multiple
            // areas where orders can be created. for example, a purchase order vs. an online order

            Console.WriteLine("The order created is an instance of type: {0}", order.GetType());


            //ShowMethodInfo(() => Order.CreateOrder(customer));
            //ShowMethodInfo(() => new Order(customer));

            Console.ReadKey();
        }








        private static void ShowMethodInfo(Expression<Action> method)
        {
            var me = method.Body as MethodCallExpression;
            if (me != null)
            {
                ShowMethodInfo(method.Body, me.Method);
                return;
            }

            var ne = method.Body as NewExpression;
            if (ne != null)
            {
                ShowMethodInfo(method.Body, ne.Constructor);
            }
        }

        private static void ShowMethodInfo(Expression expression, MethodBase methodInfo)
        {
            Console.WriteLine("----");
            Console.WriteLine("{0}", expression);
            Console.WriteLine();
            Console.WriteLine("Method name: {0}", methodInfo.Name);
            if(methodInfo is MethodInfo)
            {
                Console.WriteLine("Return Type: {0}", ((MethodInfo)methodInfo).ReturnType);
            }

            foreach (var parameter in methodInfo.GetParameters())
            {
                Console.WriteLine("Parameter {0} Type: {1}", parameter.Position, parameter.ParameterType);
                
            }
        }
    }
}