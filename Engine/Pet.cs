using System;
using System.Collections.Generic;

namespace sim.Engine
{
    public enum PetFamily
    {
        Aquatic,
        Beast,
        Critter,
    }

    public class Pet
    {
        public int Id { get; protected set; }
        public PetFamily Family { get; protected set; }
        public string Name { get; protected set; }
        public List<Spell> Spells { get; protected set; }

        public Pet(int id, PetFamily family, string name, List<Spell> spells)
        {
            Id = id;
            Family = family;
            Name = name;
            Spells = spells;
        }

        public void UseAbility(int index)
        {
            Spells[index].Cast();
        }
    }

    // public class Mouse : Pet
    // {
    //     public Mouse(PetFamily family, string name, List<Ability> abilities) : base(family, name, abilities)
    //     {
    //     }
    // }

    // public class Dog : Pet
    // {
    //     public Dog(PetFamily family, string name, List<Ability> abilities) : base(family, name, abilities)
    //     {
    //     }
    // }
}