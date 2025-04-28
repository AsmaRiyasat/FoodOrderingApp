
using System;
using System.Collections.Generic;
using System.IO;

public class CustomerDAL
{
    private string filePath = "Myfile.txt";

    public void AddCustomer(Customers customer)
    {
        FileStream fin = new FileStream(filePath, FileMode.Append);
        StreamWriter finWriter = new StreamWriter(fin);
        string data = $"{customer.Name},{customer.PhoneNumber}";
        finWriter.WriteLine(data);
        finWriter.Close();
        fin.Close();
    }

    public List<Customers> GetAll()
    {
        List<Customers> customers = new List<Customers>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return customers;
        }

        FileStream fin = new FileStream(filePath, FileMode.Open);
        StreamReader finReader = new StreamReader(fin);
        string? data;

        while ((data = finReader.ReadLine()) != null)
        {
            string[] values = data.Split(',');

            if (values.Length >= 2)
            {
                Customers customer = new Customers
                {
                    Name = values[0].Trim(),
                    PhoneNumber = values[1].Trim()
                };

                customers.Add(customer);
            }
            else
            {
                Console.WriteLine($"Invalid data format: {data}");
            }
        }

        finReader.Close();
        fin.Close();
        return customers;
    }
}

