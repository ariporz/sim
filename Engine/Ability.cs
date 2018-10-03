using System;

namespace sim.Engine
{
    public enum AbilityType
    {
        DamageDirect,
        DamageArea,
        HealDirect,
        HealArea,
    }

    public abstract class Ability
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public AbilityType Type { get; protected set; }

        public Ability(int id, string name, AbilityType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }

    public class Bite : Ability
    {
        public Bite(int id, string name, AbilityType type) : base(id, name, type)
        {
        }
    }

    public class Heal : Ability
    {
        public Heal(int id, string name, AbilityType type) : base(id, name, type)
        {
        }
    }
}