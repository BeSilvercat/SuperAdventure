using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class QuestCompletionItem
    {
        #region Declarations
        public Item Details { get; set; }
        public int Quantity { get; set; }
        #endregion

        public QuestCompletionItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
