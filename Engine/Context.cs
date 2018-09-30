using System;

namespace sim.Engine
{
    public abstract class Context
    {
        public abstract State CurrentState { get;  set; }

        public abstract void Run();
    }

    public abstract class State
    {
        protected Context context;

        public Context Context
        {
            get => context;
            set => context = value;
        }

        public abstract string GetName();
        protected abstract void Entering();
        public abstract void Running();
        protected abstract void Exiting();
        public abstract void UserInput(string userId, string input);
    }
}