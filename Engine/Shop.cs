using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class Shop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Shop(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
