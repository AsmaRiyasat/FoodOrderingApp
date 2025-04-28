using System;
using System.Collections.Generic;
using System.IO;

public class ItemDAL
{
    private string filePath = "Item.txt";

    public void AddItem(Items item)
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Append);
        StreamWriter streamWriter = new StreamWriter(fileStream);
        string itemData = $"{item.ItemName},{item.ItemPrice}";
        streamWriter.WriteLine(itemData);
        streamWriter.Close();
        fileStream.Close();
    }

    public List<Items> GetAllItems()
    {
        List<Items> items = new List<Items>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return items;
        }

        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        StreamReader streamReader = new StreamReader(fileStream);
        string itemData;

        while ((itemData = streamReader.ReadLine()) != null)
        {
            string[] dataItems = itemData.Trim().Split(',');

            if (dataItems.Length == 2)
            {
                Items item = new Items
                {
                    ItemName = dataItems[0].Trim(),
                    ItemPrice = float.Parse(dataItems[1].Trim())
                };
                items.Add(item);
            }
            else
            {
                Console.WriteLine($"Invalid Data Item Found: {itemData}");
            }
        }

        streamReader.Close();
        fileStream.Close();
        return items;
    }

    public List<Items> GetItemByName(string name)
    {
        List<Items> items = new List<Items>();

        if (!File.Exists(filePath))
            return items;

        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        StreamReader streamReader = new StreamReader(fileStream);
        string? itemData;

        while ((itemData = streamReader.ReadLine()) != null)
        {
            string[] dataItems = itemData.Trim().Split(',');

            if (dataItems.Length == 2)
            {
                if (name.Trim().Equals(dataItems[0].Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    Items item = new Items
                    {
                        ItemName = dataItems[0].Trim(),
                        ItemPrice = float.Parse(dataItems[1].Trim())
                    };
                    items.Add(item);
                }
            }
            else
            {
                Console.WriteLine($"Invalid Data Item Found: {itemData}");
            }
        }

        streamReader.Close();
        fileStream.Close();
        return items;
    }
}

