using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField, Required] private SpriteRenderer m_kitchenObjectIcon;
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlayerGrabbedObjectFromCounter;
    [SerializeField, Required] private KitchenObjectSO m_kitchenObjectSO;

    private void Awake()
    {
        SetupVisual();
    }

    private void SetupVisual()
    {
        if(m_kitchenObjectSO.IconSprite != null)
        {
            m_kitchenObjectIcon.sprite = m_kitchenObjectSO.IconSprite;
        }
    }

    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            return;
        }
        var kitchenObjectTransform = Instantiate(m_kitchenObjectSO.Prefab);
        if (kitchenObjectTransform.TryGetComponent(out KitchenObject kitchenObject))
        {
            kitchenObject.SetKitchenObjectParent(player);
            m_onPlayerGrabbedObjectFromCounter.Raise(this);
        }
    }
}
