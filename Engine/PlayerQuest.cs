using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class PlayerQuest
    {
        #region
        public Quest Details { get; set; }
        public bool IsCompleted { get; set; }
        #endregion

        public PlayerQuest(Quest details)
        {
            Details = details;
            IsCompleted = false;
        }
    }
}
