using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class LivingCreature
    {
        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }

        public int CreatureForce { get; set; }
        public int CreatureConstitution { get; set; }
        public int CreatureDexterity { get; set; }
        public int CreatureIntelligence { get; set; }
        public int CreatureWisdom { get; set; }
        public int CreatureCharisma { get; set; }
        

        public LivingCreature(int currentHitPoints, int maximumHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }
    }
}
