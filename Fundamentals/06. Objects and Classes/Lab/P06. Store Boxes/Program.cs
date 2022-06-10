using System;
using System.Collections.Generic;
using System.Linq;

namespace P6._Store_Boxes
{
    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal PriceBox { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Box> boxes = new List<Box>();
            List<Item> items = new List<Item>();

            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ');

                string serialNumber = cmdArgs[0];
                string item = cmdArgs[1];
                int itemQuantity = int.Parse(cmdArgs[2]);
                decimal price = decimal.Parse(cmdArgs[3]);

                Item newItem = new Item()
                {
                    Name = item,
                    Price = price
                };

                items.Add(newItem);

                Box newBox = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = newItem,
                    ItemQuantity = itemQuantity,
                    PriceBox = itemQuantity * newItem.Price
                };

                boxes.Add(newBox);

                command = Console.ReadLine();   
            }

            List<Box> filteredBoxes = boxes.OrderByDescending(box => box.PriceBox).ToList();

            foreach (Box box in filteredBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
        }
    }
}
