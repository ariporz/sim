using System;
using System.Collections.Generic;

namespace sim.Engine
{
    public enum TargetType
    {
        Direct,
        Area,
    }

    public enum DispelType
    {
        None,
        Magic,
    }

    public abstract class Spell
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public float Cost { get; protected set; }
        public int Cooldown { get; protected set; }
        public int Duration { get; protected set; }
        public TargetType TargetType { get; protected set; }
        public DispelType DispelType { get; protected set; }
        public List<Effect> Effects { get; protected set; }

        public Spell(int id, string name, float cost, int duration, TargetType targetType, DispelType dispelType, List<Effect> effects)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Duration = duration;
            TargetType = targetType;
            DispelType = dispelType;
            Effects = effects;
        }

        public void Cast()
        {
        }
    }

    public class Bite : Spell
    {
        public Bite(int id, string name, float cost, int duration, TargetType targetType, DispelType dispelType, List<Effect> effects)
            : base(id, name, cost, duration, targetType, dispelType, effects)
        {
        }
    }

    public class Heal : Spell
    {
        public Heal(int id, string name, float cost, int duration, TargetType targetType, DispelType dispelType, List<Effect> effects)
            : base(id, name, cost, duration, targetType, dispelType, effects)
        {
        }
    }
}