using System;
using System.Collections.Generic;

namespace sim.Engine
{
    public class AuraQueue
    {
        public event EventHandler AuraExpired;

        public List<Aura> Auras { get; protected set; }
        public List<Aura> HealingAuras
        {
            get
            {
                return Auras.FindAll(x => x.AuraType == AuraType.PeriodicHeal && x.Trigger());
            }
        }
        public List<Aura> DamageAuras
        {
            get
            {
                return Auras.FindAll(x => x.AuraType == AuraType.PeriodicDamage && x.Trigger());
            }
        }

        public AuraQueue()
        {
        }

        public void AddToQueue(Aura aura)
        {
            Auras.Add(aura);
        }

        public void Refresh()
        {
            foreach(Aura aura in Auras.FindAll(x => x.Ticks <= 0))
            {
                Auras.Remove(aura);
                OnAuraExpired(aura);
            }
        }

        protected void OnAuraExpired(Aura aura)
        {
            AuraExpired?.Invoke(aura, EventArgs.Empty);
        }
    }
}