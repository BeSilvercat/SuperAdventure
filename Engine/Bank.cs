using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class Bank
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GoldAmount { get; set; }
        public int AvailableGold { get; set; }

        public Bank(int id, string name, string description, int availableGold)
        {
            ID = id;
            Name = name;
            Description = description;
            AvailableGold = AvailableGold;
            
        }

        public void SaveGoldToBank(int goldAmount)
        {
            AvailableGold += goldAmount;
        }

        public void RetreiveGoldFromBank(int goldAmount)
        {
            if(AvailableGold - goldAmount > 0)
            {
                AvailableGold -= goldAmount;
            }
        }
    }


}