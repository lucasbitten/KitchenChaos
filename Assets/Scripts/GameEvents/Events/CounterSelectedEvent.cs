using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CounterSelectedEvent;

[CreateAssetMenu(menuName = "GameEvents/CounterSelectedEvent")]
public class CounterSelectedEvent : GameEvent_WithArgs<Args>
{
    public class Args : GameEvent_Args
    {
        public ClearCounter Counter;
    }
}
