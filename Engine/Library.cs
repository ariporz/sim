using System;
using System.Collections.Generic;

namespace sim.Engine
{
    public static class Library
    {
        public static Dictionary<int, Spell> Spells { get; private set; }
        public static Dictionary<int, Pet> Pets { get; private set; }

        static Library()
        {
            Spells = new Dictionary<int, Spell>();
            Pets = new Dictionary<int, Pet>();

            CreateSpells();
            CreatePets();
        }

        public static Spell GetSpellById(int id)
        {
            Spell spell = null;
            Spells.TryGetValue(id, out spell);
            return spell;
        }

        public static Pet GetPetById(int id)
        {
            Pet pet = null;
            Pets.TryGetValue(id, out pet);
            return pet;
        }

        private static void CreateSpells()
        {
            List<Effect> effects = new List<Effect>();
            EffectDamage effectDamage = new EffectDamage(3000, "Effect Damage", EffectType.Damage, TargetType.Direct, 0.5f, null);
            effects.Add(effectDamage);
            Bite bite = new Bite(2000, "Bite", 1.5f, 0, TargetType.Direct, DispelType.None, effects);
            Spells.Add(bite.Id, bite);

            effects = new List<Effect>();
            effectDamage = new EffectDamage(3001, "Effect Damage", EffectType.Damage, TargetType.Direct, 0.5f, null);
            effects.Add(effectDamage);
            bite = new Bite(2001, "Scratch", 0f, 0, TargetType.Direct, DispelType.None, effects);
            Spells.Add(bite.Id, bite);

            effects = new List<Effect>();
            effects.Add(new EffectDamage(3000, "Effect Damage", EffectType.Damage, TargetType.Direct, 0.25f, null));
            effects.Add(new EffectDamage(3001, "Effect Damage", EffectType.Damage, TargetType.Direct, 0.50f, null));
            effects.Add(new EffectDamage(3002, "Effect Damage", EffectType.Damage, TargetType.Direct, 0.75f, null));
            var test = effects.FindAll(x => { if (x.Id < 3002) return true; else return false; });
        }

        private static void CreatePets()
        {
            List<Spell> spells = new List<Spell>();
            spells.Add(GetSpellById(2000));
            Pet pet = new Pet(1, PetFamily.Beast, "Dog", spells);
            Pets.Add(pet.Id, pet);

            spells = new List<Spell>();
            spells.Add(GetSpellById(2001));
            pet = new Pet(2, PetFamily.Critter, "Mouse", spells);
            Pets.Add(pet.Id, pet);
        }
    }
}