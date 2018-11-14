using System;
using System.Collections.Generic;

namespace sim.Engine
{
    public class CombatContext
    {
        private List<string> CombatQueue;

        public bool InCombat { get; protected set; }

        public void StartCombat()
        {
            InCombat = true;
        }

        public void EndCombat()
        {
            InCombat = false;
        }

        public void AddToQueue(int playerId, int petId, int spellId)
        {
        }
    }
}