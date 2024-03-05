using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class BaseGameEvent<T> : ScriptableObject
{

    // Event keyword makes it so that only this class can trigger the event
    //Public because anyone can subscribe(+=), and unsubscribe(-=) to/from this event
    public event Action<T> EventListeners = delegate { };

    [ContextMenu("Raise Event")]
    public void Raise(T item)
    {
        EventListeners(item);
    }

}
