using System;

namespace sim.Engine
{
    public enum AuraType
    {
        PeriodicDamage,
        PeriodicHeal,
        ModDamageTaken,
        ModMaximumHealth,
    }

    public class Aura
    {
        // TODO: Do we need to make Aura abstract, derive DamageAura, HealAura, etc. with each Trigger() performing differently?
        public int Id { get; protected set; }
        public AuraType AuraType { get; protected set; }
        public int Interval { get; protected set; }
        public int Ticks { get; protected set; }
        public int Duration { get; protected set; }
        public float Power { get; protected set; }

        private int accumulated;

        public Aura(int duration, float power)
        {
            Power = power;
            Duration = duration;
            accumulated = 0;
            if (Duration == 0 || Interval == 0)
            {
                Ticks = 0;
            }
            else
            {
                Ticks = (int)(Duration / Interval);
            }
        }

        public bool Trigger()
        {
            var result = false;

            accumulated += 1;

            if (accumulated >= Interval)
            {
                accumulated = 0;
                Ticks -= 1;
                result = true;
            }

            return result;
        }
    }
}