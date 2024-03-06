using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvents/GameEvent")]
public class GameEvent : BaseGameEvent<Void>
{
    public void Raise() => Raise(new Void());
}