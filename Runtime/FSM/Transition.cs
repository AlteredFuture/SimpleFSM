using System;

namespace FSM
{
    public class Transition
    {
        public string m_To;

        public Func<bool> m_Condition;

        public Transition(string to, Func<bool> condition)
        {
            this.m_Condition = condition;
            this.m_To = to;
        }
    }
}