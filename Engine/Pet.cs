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

    public abstract class Pet
    {
        public PetFamily Family { get; protected set; }
        public string Name { get; protected set; }
        public List<Ability> Abilities { get; protected set; }

        public Pet(PetFamily family, string name, List<Ability> abilities)
        {
            Family = family;
            Name = name;
            Abilities = abilities;
        }
    }

    public class Mouse : Pet
    {
        public Mouse(PetFamily family, string name, List<Ability> abilities) : base(family, name, abilities)
        {
        }
    }

    public class Dog : Pet
    {
        public Dog(PetFamily family, string name, List<Ability> abilities) : base(family, name, abilities)
        {
        }
    }
}