using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlayerGrabbedObjectFromCounter;

    [SerializeField, Required] private KitchenObjectSO m_kitchenObjectSO;

    public override void Interact(Player player)
    {
        var kitchenObjectTransform = Instantiate(m_kitchenObjectSO.Prefab);
        if (kitchenObjectTransform.TryGetComponent(out KitchenObject kitchenObject))
        {
            kitchenObject.SetKitchenObjectParent(player);
            m_onPlayerGrabbedObjectFromCounter.Raise(this);
        }
    }
}
