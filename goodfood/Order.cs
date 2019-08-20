using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace goodfood
{
    public class Order
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public bool OrderDelivered { get; set; }

        public Order(int id, string client, string product, int amount, double price, DateTime date, bool orderDelivered)
        {
            Id = id;
            Client = client;
            Product = product;
            Amount = amount;
            Price = price;
            Date = date;
            OrderDelivered = orderDelivered;
        }
        public Order(string client, string product, int amount, double price, DateTime date, bool orderDelivered)
        {
            Client = client;
            Product = product;
            Amount = amount;
            Price = price;
            Date = date;
            OrderDelivered = orderDelivered;
        }
    }
}