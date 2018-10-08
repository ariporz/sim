using System;
using System.Collections.Generic;

namespace sim.Engine
{
    public abstract class Player
    {
        public event EventHandler InputReceived;

        public int PlayerId { get; protected set; }
        public string PlayerName { get; protected set; }

        public bool PlayerRoundInputGiven { get; set; }
        public int PlayerRoundInput { get; protected set; }

        public List<Pet> ActivePets { get; protected set; }
        public int ActiveSlot { get; protected set; }

        public abstract void GetPlayerInput();

        protected virtual void OnInputReceived()
        {
            InputReceived?.Invoke(this, EventArgs.Empty);
        }
    }

    public class HumanPlayer : Player
    {
        public HumanPlayer(string playerName)
        {
            PlayerId = 1;
            PlayerName = playerName;
            ActivePets = new List<Pet>();
            List<Spell> spells = new List<Spell>();
            spells.Add(new Bite(1, "Bite", TargetType.Direct));
            spells.Add(new Bite(5, "Big Bite", TargetType.Area));
            ActivePets.Add(new Pet(PetFamily.Beast, "Big Dog", spells));
            spells = new List<Spell>();
            spells.Add(new Bite(3, "Scratch", TargetType.Direct));
            spells.Add(new Heal(6, "Healing Prayer", TargetType.Area));
            ActivePets.Add(new Pet(PetFamily.Critter, "Small Mouse", spells));
            ActiveSlot = 0;
        }

        public override void GetPlayerInput()
        {
            var result = -1;

            Console.WriteLine();
            Console.WriteLine($"Player: {PlayerName}");
            Console.Write("Input: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out result))
            {
                PlayerRoundInput = result;
                PlayerRoundInputGiven = true;
                OnInputReceived();
            }
        }
    }

    public class AIPlayer : Player
    {
        public AIPlayer()
        {
            PlayerId = 0;
            PlayerName = "Roboter";
            ActivePets = new List<Pet>();
            List<Spell> spells = new List<Spell>();
            spells.Add(new Bite(1, "Bite", TargetType.Direct));
            spells.Add(new Heal(2, "Heal", TargetType.Direct));
            ActivePets.Add(new Pet(PetFamily.Beast, "Dog", spells));
            spells = new List<Spell>();
            spells.Add(new Bite(3, "Scratch", TargetType.Direct));
            spells.Add(new Heal(4, "Squeal", TargetType.Direct));
            ActivePets.Add(new Pet(PetFamily.Critter, "Mouse", spells));
            ActiveSlot = 0;
        }

        public override void GetPlayerInput()
        {
            PlayerRoundInput = 1;
            PlayerRoundInputGiven = true;
            OnInputReceived();
        }
    }
}