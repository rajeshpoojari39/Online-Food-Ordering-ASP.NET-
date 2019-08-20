using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code
{
    public class Menu
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type{ get; set; }
        public double price { get; set; }
        public string image { get; set; }

        public Menu(int id,string name,string type,double price,string image)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.price = price;
            this.image = image;
        }
    }
}