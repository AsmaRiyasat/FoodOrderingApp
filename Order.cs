using System;


    public class Order
    {
        private static string filePath = "OrderInfo.txt";
        public void OrderProcessing(Customers customer, List<Items> orderedItems)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string data = $"Customer: {customer.Name}\nOrdered Items:";
            streamWriter.WriteLine(data);
            foreach (var item in orderedItems)
            {
                   streamWriter.WriteLine(item.ToString());
            }
                
            streamWriter.WriteLine();
            streamWriter.Close();
            fileStream.Close();
        }

        public static void ShowOrders()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No order found!");
                return;
            }

            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
             string? data;
            while ((data = streamReader.ReadLine()) != null)
        {
                Console.WriteLine(data);
            }
            streamReader.Close();
            fileStream.Close();
        }
    }

