using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class LootItem
    {
        #region Declarations
        public Item Details { get; set; }
        public int DropPercentage { get; set; }
        public bool IsDefaultItem { get; set; }
        #endregion

        public LootItem(Item details, int dropPercentage, bool isDefaultItem)
        {
            Details = details;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}
