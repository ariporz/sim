using System;
using System.Collections.Generic;

namespace sim.Engine
{
    // public enum OldState
    // {
    //     Idle,
    //     CombatStarting,
    //     RoundStarting,
    //     AbilitySelecting,
    //     AbilityExecuting,
    //     RoundEnding,
    //     CombatEnding,
    // }
    public class GameContext
    {
        private int round = 0;
        private State state;
        private List<Player> players = new List<Player>();

        public event EventHandler StateChanged;

        public State CurrentState
        {
            get => state;
            set
            {
                if (state != value)
                {
                    state.Exiting();
                    OnStateChanged(value);
                    state = value;
                    state.Entering();
                }
            }
        }

        public bool Exit
        {
            get => (CurrentState is CombatEnding);
        }

        public int Round
        {
            get => round;
            set => round = value;
        }

        public List<Player> Players { get => players; }

        public GameContext()
        {
            state = new CombatStarting(this);
            players.Add(new HumanPlayer("Bob"));
            players.Add(new AIPlayer());
        }

        public void Run()
        {
            state.Running();
        }

        protected void OnStateChanged(State newState)
        {
            StateChanged?.Invoke(newState, EventArgs.Empty);
        }
    }

    public abstract class State
    {
        //protected GameContext context;
        protected CombatContext combat;

        public event EventHandler StateEvent;

        protected GameContext Context { get; set; }

        protected CombatContext CombatContext
        {
            get => combat;
            set => combat = value;
        }

        public string GetName()
        {
            return this.ToString();
        }

        public abstract void Entering();
        public abstract void Running();
        public abstract void Exiting();
        public abstract void UserInput(int userId, int input);

        protected void OnStateEvent(State state)
        {
            StateEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public class CombatStarting : State
    {
        // public CombatStarting(State state) : this(state.Context) { }

        public CombatStarting(GameContext context)
        {
            Context = context;
        }

        public override void Entering()
        {
            Context.Round = 0;
            // Console.WriteLine($"Entering - {GetName()}");
        }

        public override void Running()
        {
            Console.WriteLine($"Combat started, teams locked.");
            // Console.WriteLine($"Running - {GetName()}");
            StateChangeCheck(null);
        }

        public override void Exiting()
        {
            // Console.WriteLine($"Exiting - {GetName()}");
        }

        public override void UserInput(int userId, int input)
        {
            if (input == 5)
            {
                StateChangeCheck(new CombatEnding(Context));
            }
        }

        private void StateChangeCheck(State state)
        {
            if (state != null)
            {
                Context.CurrentState = state;
            }
            else
            {
                Context.CurrentState = new RoundStarting(Context);
            }
        }
    }

    public class RoundStarting : State
    {
        public RoundStarting(GameContext context)
        {
            Context = context;
        }

        public override void Entering()
        {
            Context.Round += 1;
            // Console.WriteLine($"Entering - {GetName()}");
        }

        public override void Running()
        {
            // Console.WriteLine($"Running - {GetName()}");
            Console.WriteLine($"Round: {Context.Round}");
            StateChangeCheck(null);
        }

        public override void Exiting()
        {
            // Console.WriteLine($"Exiting - {GetName()}");
        }

        public override void UserInput(int userId, int input)
        {
            if (input == 5)
            {
                StateChangeCheck(new CombatEnding(Context));
            }
        }

        private void StateChangeCheck(State state)
        {
            if (state != null)
            {
                Context.CurrentState = state;
            }
            else
            {
                Context.CurrentState = new AbilitySelecting(Context);
            }
        }
    }

    public class AbilitySelecting : State
    {
        public AbilitySelecting(GameContext context)
        {
            Context = context;
        }

        public override void Entering()
        {
            // Console.WriteLine($"Entering - {GetName()}");
        }

        public override void Running()
        {
            // Console.WriteLine($"Running - {GetName()}");

            var complete = true;
            
            foreach (Player player in Context.Players)
            {
                if (!player.PlayerRoundInputGiven)
                {
                    player.GetPlayerInput();
                }
            }

            foreach (Player player in Context.Players)
            {
                if (!player.PlayerRoundInputGiven)
                {
                    complete = false;
                }
            }

            StateChangeCheck((complete) ? new AbilityExecuting(Context) : null);
        }

        public override void Exiting()
        {
            // Console.WriteLine($"Exiting - {GetName()}");
        }

        public override void UserInput(int userId, int input)
        {
            if (input == 5)
            {
                StateChangeCheck(new CombatEnding(Context));
            }
        }

        private void StateChangeCheck(State state)
        {
            if (state != null)
            {
                Context.CurrentState = state;
            }
        }
    }

    public class AbilityExecuting : State
    {
        public AbilityExecuting(GameContext context)
        {
            Context = context;
        }

        public override void Entering()
        {
            // Console.WriteLine($"Entering - {GetName()}");
            foreach (Player player in Context.Players)
            {
                player.PlayerRoundInputGiven = false;
            }
        }

        public override void Running()
        {
            Console.WriteLine($"Running - {GetName()}");
            StateChangeCheck();
        }

        public override void Exiting()
        {
            Console.WriteLine($"Exiting - {GetName()}");
        }

        public override void UserInput(int userId, int input)
        {
            
        }

        private void StateChangeCheck()
        {
        }
    }

    public class RoundEnding : State
    {
        public RoundEnding(GameContext context)
        {
            Context = context;
        }

        public override void Entering()
        {
            Console.WriteLine($"Entering - {GetName()}");
        }

        public override void Running()
        {
            Console.WriteLine($"Running - {GetName()}");
            StateChangeCheck();
        }

        public override void Exiting()
        {
            Console.WriteLine($"Exiting - {GetName()}");
        }

        public override void UserInput(int userId, int input)
        {
            
        }

        private void StateChangeCheck()
        {
        }
    }

    public class CombatEnding : State
    {
        public CombatEnding(GameContext context)
        {
            Context = context;
        }

        public override void Entering()
        {
            Console.WriteLine($"Entering - {GetName()}");
        }

        public override void Running()
        {
            Console.WriteLine($"Running - {GetName()}");
            StateChangeCheck();
        }

        public override void Exiting()
        {
            Console.WriteLine($"Exiting - {GetName()}");
        }

        public override void UserInput(int userId, int input)
        {
            
        }

        private void StateChangeCheck()
        {
        }
    }
}