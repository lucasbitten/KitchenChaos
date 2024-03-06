using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvents/OnStoveStateChangedEvent")]
public class OnStoveStateChangedEvent : GameEvent_WithArgs<OnStoveStateChangedEvent.EventArgs>
{
    public class EventArgs : GameEvent_Args
    {
        public EventArgs(StoveCounter stoveCounter, StoveCounter.State state)
        {
            StoveCounter = stoveCounter;
            State = state;
        }

        public StoveCounter StoveCounter { get; private set; }
        public StoveCounter.State State { get; private set; }
    }
}
