using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField, Required] private Transform m_counterTopPoint;

    private KitchenObject m_kitchenObject;

    public abstract void Interact(Player player);

    public virtual void InteractAlternate(Player player)
    {

    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return m_counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        m_kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return m_kitchenObject;
    }

    public void ClearKitchenObject()
    {
        m_kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return m_kitchenObject != null;
    }
}
