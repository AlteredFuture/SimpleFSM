using System.Collections.Generic;
using UnityEngine;

namespace AITools
{
    public abstract class FsmState<T> : FsmState
    {
        public readonly T m_Data;

        protected FsmState( T data,FsmController fsm) : base(fsm)
        {
            this.m_Data = data;
        }


    }

    public abstract class FsmState
    {
        protected FsmState(FsmController fsm)
        {
            m_Fsm = fsm;
        }

        public abstract void OnEnter();

        public abstract void OnExit();

        public abstract void OnUpdate(float deltaTime);

        /// <summary>
        /// what cases will case the state to Transition to another state
        /// </summary>
        public List<Transition> m_Transitions = new List<Transition>();
        
        public FsmController m_Fsm;

 

    }
}