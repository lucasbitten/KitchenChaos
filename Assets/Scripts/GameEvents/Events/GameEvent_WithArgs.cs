using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent_WithArgs<T> : BaseGameEvent<T> where T : GameEvent_Args
{

}

public abstract class GameEvent_Args
{

}