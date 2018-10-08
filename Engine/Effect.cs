using System;

namespace sim.Engine
{
    public enum EffectType
    {
        Damage,
        Heal,
        Buff,
        Debuff,
    }

    public abstract class Effect
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public EffectType EffectType { get; protected set; }
        public TargetType TargetType { get; protected set; }
        public float Power { get; protected set; }
    }

    public class EffectDamage : Effect
    {
        public EffectDamage(int id, string name, EffectType effectType, TargetType targetType, float power)
        {
            Id = id;
            Name = name;
            EffectType = effectType;
            TargetType = targetType;
            Power = power;
        }
    }
}