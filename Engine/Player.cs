using System;

namespace sim.Engine
{
    public abstract class Player
    {
        public event EventHandler InputReceived;

        public int PlayerId { get; protected set; }
        public string PlayerName { get; protected set; }

        public bool PlayerRoundInputGiven { get; set; }
        public int PlayerRoundInput { get; protected set; }

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
        }

        public override void GetPlayerInput()
        {
            PlayerRoundInput = 1;
            PlayerRoundInputGiven = true;
            OnInputReceived();
        }
    }
}