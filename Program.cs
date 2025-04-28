using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        CustomerDAL customerDAL = new CustomerDAL();
        ItemDAL itemManager = new ItemDAL();
        Order orderProcessor = new Order();

        while (true)
        {
            Console.WriteLine("\n===== Menu =====");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. View All Customers");
            Console.WriteLine("3. Add Item");
            Console.WriteLine("4. View All Items");
            Console.WriteLine("5. Place an Order");
            Console.WriteLine("6. View All Orders");
            Console.WriteLine("7. Search Item by Name");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Add a new customer
                    Console.Write("Enter Customer Name: ");
                    string customerName = Console.ReadLine();
                    Console.Write("Enter Customer Phone Number: ");
                    string customerPhone = Console.ReadLine();
                    Customers newCustomer = new Customers(customerName, customerPhone);
                    customerDAL.AddCustomer(newCustomer);
                    Console.WriteLine("Customer added successfully!");
                    break;

                case "2":
                    // View all customers
                    Console.WriteLine("\n===== List of Customers =====");
                    List<Customers> customers = customerDAL.GetAll();
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer.ToString());
                    }
                    break;

                case "3":
                    // Add a new item
                    Console.Write("Enter Item Name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter Item Price: ");
                    float itemPrice = float.Parse(Console.ReadLine());
                    Items newItem = new Items { ItemName = itemName, ItemPrice = itemPrice };
                    itemManager.AddItem(newItem);
                    Console.WriteLine("Item added successfully!");
                    break;

                case "4":
                    // View all items
                    Console.WriteLine("\n===== List of Items =====");
                    List<Items> items = itemManager.GetAllItems();
                    if (items.Count > 0)
                    {

                        foreach (var item in items)
                        {
                            Console.WriteLine($"Item NAme:{item.ItemName},Item Price:{item.ItemPrice}");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Item Found");

                    }
                    break;

                

                case "5":
                    
                    Console.WriteLine("\n===== Placing an Order =====");
                    Console.WriteLine("\nAvailable Items:");
                    List<Items> availableItems = itemManager.GetAllItems();

                    foreach (var item in availableItems)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    Console.Write("Enter Customer Name: ");
                    string orderCustomerName = Console.ReadLine();
                    List<Customers> customerList = customerDAL.GetAll();

                    
                    Customers orderCustomer = null;
                    foreach (var customer in customerList)
                    {
                        if (customer.Name.Equals(orderCustomerName, StringComparison.OrdinalIgnoreCase))
                        {
                            orderCustomer = customer;
                            break;  
                        }
                    }

                    if (orderCustomer == null)
                    {
                        Console.WriteLine("Customer with this name does not exist!");
                        break;
                    }

                    List<Items> orderItems = new List<Items>();

                    while (true)
                    {
                        Console.Write("Enter Item Name (or type 'done' to finish): ");
                        string selectedItemName = Console.ReadLine();

                        if (selectedItemName.ToLower() == "done")
                            break;

                        List<Items> itemByName = itemManager.GetItemByName(selectedItemName);
                        if (itemByName.Count > 0)
                        {
                            orderItems.Add(itemByName[0]);
                        }
                        else
                        {
                            Console.WriteLine("Item not found! Try again.");
                        }
                    }

                    if (orderItems.Count == 0)
                    {
                        Console.WriteLine("No valid items added. Order not placed.");
                        break;
                    }

                    orderProcessor.OrderProcessing(orderCustomer, orderItems);
                    Console.WriteLine("Order placed successfully!");
                    break;


                case "6":
                    
                    Console.WriteLine("\n===== All Orders =====");
                    Order.ShowOrders();
                    break;

                case "7":

                    
                    Console.WriteLine("Enter the item name you want to search for:");
                    string? search = Console.ReadLine();

                    List<Items> foundItems = itemManager.GetItemByName(search);

                    if (foundItems.Count > 0)
                    {
                        Console.WriteLine("\n===== Items Found =====");
                        foreach (var item in foundItems)
                        {
                            Console.WriteLine($"Item Name: {item.ItemName}, Item Price: {item.ItemPrice}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No items found with the name: {search}");
                    }
                    break;

                case "8":
                   
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}


