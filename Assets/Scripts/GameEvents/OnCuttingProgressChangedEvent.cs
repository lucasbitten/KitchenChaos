using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvents/OnCuttingProgressChangedEvent")]
public class OnCuttingProgressChangedEvent : GameEvent_WithArgs<OnCuttingProgressChangedEvent.EventArgs>
{
    public class EventArgs : GameEvent_Args
    {
        public EventArgs(CuttingCounter cuttingCounter, float progressNormalized)
        {
            CuttingCounter = cuttingCounter;
            ProgressNormalized = progressNormalized;
        }

        public CuttingCounter CuttingCounter { get; private set; }
        public float ProgressNormalized { get; private set; }
    }
}
