using System;
using System.Globalization;
using Exercicio_pedido_sumario.Entities;
using Exercicio_pedido_sumario.Entities.Enums;

namespace Exercicio_pedido_sumario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("\nHotw many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for(int i =1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item, data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }
            Console.WriteLine("\nORDER SUMMARY: " + order);
            
        }
    }
}
