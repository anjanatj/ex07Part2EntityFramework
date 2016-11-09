using System;
using System.Collections.Generic;
using SportsStore.Data;
using SportsStore.Models;
using System.Linq;

namespace SportsStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                //Drop database en Migreer

                //Console.WriteLine("Database is aangemaakt");

                var products = context.Products.ToList();
                products.ForEach(c => Console.WriteLine(c.Name));

                //var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                //var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                //loggerFactory.AddProvider(new MyFilteredLoggerProvider());
                
                DoExercise(context);
            }
            Console.ReadLine();

        }

        private static void DoExercise(ApplicationDbContext context)
        {

            IEnumerable<Product> products;
            Product product;
            IEnumerable<Customer> customers;
            Customer customer;

            //Selecteer de category soccer en watersports. Plaats onderstaande uit commentaar
            //Category soccer = null;
            //Category watersports = null;

            Console.WriteLine("--1. Alle producten gesorteerd op prijs oplopend, dan op naam--");
            products = context.Products;
            WriteProducts(products);

            Console.WriteLine("\n--2. Alle klanten die wonen te gent, gesorteerd op naam --");
            customers = context.Customers;
            WriteCustomers(customers);

            Console.WriteLine("\n--3. Het aantal klanten in Gent--");
            Console.WriteLine("...");

            Console.WriteLine("\n--4. De klant met  customername student4. --");
            customer = null;
            if (customer != null)
                Console.WriteLine(customer.Name + " " + customer.FirstName);

            Console.WriteLine("\n--5. Vervolg op vorige query. Print nu de orders van die klant af. Print (methode WriteOrder) de Orderdate, DeliveryDate, en Total af. --");
            //Haal de klant niet opnieuw op! Haal klant en zijn Orders en Orderlines in 1 keer op. 
            //zie methode WriteOrder voor het weergeven van een order
            if (customer != null)
                foreach (Order o in customer.Orders)
                    WriteOrder(o);

            Console.WriteLine("\n--6. Alle producten van de categorie soccer, gesorteerd op prijs descending--");
            products = new List<Product>();
            WriteProducts(products);

            Console.WriteLine("\n--7A. Maak een nieuwe cart aan en voeg product met id 1 toe(aantal 2). Plaatst dan een order voor student 4 voor deze cart, deliverydate binnen 20 dagen, giftwrapping false en deliveryAddress = adres van de klant--");
            Product p1 = null;
            Cart cart = new Cart();
            cart.AddLine(p1, 2);

            Console.WriteLine("\n--7B. Plaatst dan een order voor student 4 voor deze cart, deliverydate binnen 20 dagen, giftwrapping false en deliveryAddress = adres van de klant--. Persisteer in database. Print vervolgens alle orders van de klant.");
            customer = null;
            if (customer != null)
                customer.PlaceOrder(cart, DateTime.Today.AddDays(20), false, customer.Street, customer.City);
            context.SaveChanges();
            if (customer != null)
                foreach (Order o in customer.Orders)
                    WriteOrder(o);

            Console.WriteLine("\n--8. Alle klanten met een order met DeliveryDate binnen de 10 dagen--");
            customers = context.Customers;
            WriteCustomers(customers);

            Console.WriteLine("\n--9. Alle klanten die een product met id 1  hebben besteld--");
            product = context.Products.FirstOrDefault(p => p.ProductId == 1);
            //Alle klanten die dit product hebben besteld
            customers = context.Customers;
            WriteCustomers(customers);

            Console.WriteLine("\n--10. Alle klanten met orders, met vermelding van aantal orders. Maak gebruik van een anoniem type--");
            var customers2 =
                context.Customers;
            foreach (var c in customers2)
                Console.WriteLine(c.Name + " " + c.Orders);


            Console.WriteLine("\n--11. Pas de naam aan van klant student5, in je eigen naam en voornaam--");
            customer = context.Customers.SingleOrDefault(c => c.CustomerName == "student5");
            WriteCustomers(customers);

            Console.WriteLine("\n--12A. Verwijder de eerste klant (in alfabetische volgorde van customername) zonder orders--");
            customer = null;
            WriteCustomers(context.Customers);

            Console.WriteLine("\n--13. Maak een nieuw product training, prijs 80, aan die behoort tot de categorie soccer en watersports en print na toevoeging aan de database het productid af--");
            Product training = null;
            //Console.WriteLine(soccer.FindProduct("training")?.ProductId);


            Console.WriteLine("\n--14. Product training behoort niet langer tot de category soccer. Ga na of CategoryProduct ook verwijderd wordt-");
            //if (training != null)
            //    soccer.RemoveProduct(training);

            Console.WriteLine("\n--15. Probeer de stad Gent te verwijderen. Waarom lukt dit niet?--");
            City city = context.Cities.FirstOrDefault(c => c.Name == "Gent");
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Verwijderen Gent faalt. Reason : {ex.Message}");
            }
            Console.ReadKey();
        }

        private static void WriteOrder(Order o)
        {
            if (o != null)
                Console.WriteLine($"{o.DeliveryDate} {o.OrderDate} {o.Total}");
        }


        private static void WriteCustomers(IEnumerable<Customer> customers)
        {
            customers.ToList().ForEach(c => Console.WriteLine($"{c.Name} {c.FirstName}"));
        }

        private static void WriteProducts(IEnumerable<Product> products)
        {
            products.ToList().ForEach(p => Console.WriteLine($"{p.ProductId} {p.Name} {p.Price:0.00}"));
        }
    }
}

