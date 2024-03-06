using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvents/OnProgressChangedEvent")]
public class OnProgressChangedEvent : GameEvent_WithArgs<OnProgressChangedEvent.EventArgs>
{
    public class EventArgs : GameEvent_Args
    {
        public EventArgs(IHasProgress hasProgress, float progressNormalized)
        {
            HasProgress = hasProgress;
            ProgressNormalized = progressNormalized;
        }

        public IHasProgress HasProgress { get; private set; }
        public float ProgressNormalized { get; private set; }
    }
}
