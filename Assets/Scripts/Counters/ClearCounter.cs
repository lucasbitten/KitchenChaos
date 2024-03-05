using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField, Required] protected KitchenObjectSO m_kitchenObjectSO;

    public override void Interact(Player player)
    {

    }
}
