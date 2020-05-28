using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AITools
{
    [Serializable]
    public class FsmController
    {
        private bool m_Started = false;

        private FsmState m_CurrentState;

        private Action m_OnFsmDone;

        private Action m_OnFsmStart;

        private List<FsmState> m_States;

        public BlackBoard m_Blackboard = new BlackBoard();


        public FsmState GetState<T>()
        {
            return m_States.Find(x => x is T);
        }

        public FsmState GetState(string state)
        {
            return m_States.Find(x => x.GetType().Name.Equals(state));
        }


        public void AddStates(List<FsmState> states)
        {
            m_States = states;
        }

        public void ChangeState(FsmState state)
        {
            m_CurrentState?.OnExit();
            m_CurrentState = state;
            state.OnEnter();
        }

        public void FsmUpdate(float delta)
        {
            if (!m_Started) return;
            m_CurrentState.OnUpdate(delta);
            CheckState();
        }

        public void CheckState()
        {
            foreach (Transition currentStateMapping in m_CurrentState.m_Transitions)
            {
                if (currentStateMapping.m_Condition.Invoke())
                {
                    ChangeState(GetState(currentStateMapping.m_To));
                }
            }
        }

        public void StartFsm(FsmState startState)
        {
            ChangeState(startState);
            m_Started = true;
            m_OnFsmStart?.Invoke();
        }

        public void Stop()
        {
            m_Started = false;
        }
    }
}