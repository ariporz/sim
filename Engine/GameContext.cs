using System;

namespace sim.Engine
{
    // public enum OldState
    // {
    //     CombatStarting,
    //     RoundStarting,
    //     AbilitySelecting,
    //     AbilityExecuting,
    //     RoundEnding,
    //     CombatEnding,
    // }
    public class GameContext : Context
    {
        private State state;

        public override State CurrentState
        {
            get => state;
            set => state = value;
        }

        public GameContext()
        {
            this.state = new CombatStarting(this);
        }

        public void UserInput(string userId, string input)
        {
            
        }

        public override void Run()
        {
            this.state.Running();
        }
    }

    public class CombatStarting : State
    {
        public CombatStarting(State state) : this(state.Context) { }

        public CombatStarting(Context context)
        {
            this.context = context;
            Entering();
        }

        public override string GetName()
        {
            return this.ToString();
        }

        protected override void Entering()
        {
            Console.WriteLine($"Entering - {this.GetName()}");
        }

        public override void Running()
        {
            Console.WriteLine($"Running - {this.GetName()}");
            StateChangeCheck();
        }

        protected override void Exiting()
        {
            Console.WriteLine($"Exiting - {this.GetName()}");
        }

        public override void UserInput(string userId, string input)
        {
        }

        private void StateChangeCheck()
        {
            Exiting();
            context.CurrentState = new RoundStarting(this);
        }
    }

    public class RoundStarting : State
    {
        public RoundStarting(State state)
        {
            this.context = state.Context;
            Entering();
        }

        public override string GetName()
        {
            return this.ToString();
        }

        protected override void Entering()
        {
            Console.WriteLine($"Entering - {this.GetName()}");
        }

        public override void Running()
        {
            Console.WriteLine($"Running - {this.GetName()}");
            StateChangeCheck();
        }

        protected override void Exiting()
        {
            Console.WriteLine($"Exiting - {this.GetName()}");
        }

        public override void UserInput(string userId, string input)
        {
            
        }

        private void StateChangeCheck()
        {
            Exiting();
            context.CurrentState = new AbilitySelecting(this);
        }
    }

    public class AbilitySelecting : State
    {
        public AbilitySelecting(State state)
        {
            this.context = state.Context;
            Entering();
        }

        public override string GetName()
        {
            return this.ToString();
        }

        protected override void Entering()
        {
            Console.WriteLine($"Entering - {this.GetName()}");
        }

        public override void Running()
        {
            Console.WriteLine($"Running - {this.GetName()}");
            StateChangeCheck();
        }

        protected override void Exiting()
        {
            Console.WriteLine($"Exiting - {this.GetName()}");
        }

        public override void UserInput(string userId, string input)
        {
            
        }

        private void StateChangeCheck()
        {
            Exiting();
        }
    }
}