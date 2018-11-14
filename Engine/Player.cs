using System;
using System.Collections.Generic;

namespace sim.Engine
{
    public abstract class Player
    {
        // TODO: Add ability queue, not every turn requires input.
        public event EventHandler InputReceived;

        public int PlayerId { get; protected set; }
        public string PlayerName { get; protected set; }

        public bool PlayerRoundInputGiven { get; set; }
        public int PlayerRoundInput { get; protected set; }

        public Dictionary<int, Pet> ActivePets { get; protected set; }
        public int ActiveId { get; protected set; }

        public abstract void GetPlayerInput();

        protected virtual void OnInputReceived()
        {
            InputReceived?.Invoke(this, EventArgs.Empty);
        }

        public void SetActivePet(int id)
        {
            ActiveId = id;
        }

        public void AddAbilityToQueue(int index)
        {
            //ActivePets[ActiveId].Spells[index];
        }
    }

    public class HumanPlayer : Player
    {
        public HumanPlayer(string playerName)
        {
            PlayerId = 1;
            PlayerName = playerName;
            ActivePets = new Dictionary<int, Pet>();
            ActivePets.Add(Library.GetPetById(2).Id, Library.GetPetById(2));
            ActivePets.Add(Library.GetPetById(1).Id, Library.GetPetById(1));
            ActiveId = 2;
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
            ActivePets = new Dictionary<int, Pet>();
            ActivePets.Add(Library.GetPetById(1).Id, Library.GetPetById(1));
            ActivePets.Add(Library.GetPetById(2).Id, Library.GetPetById(2));
            ActiveId = 1;
        }

        public override void GetPlayerInput()
        {
            PlayerRoundInput = 1;
            PlayerRoundInputGiven = true;
            OnInputReceived();
        }
    }
}