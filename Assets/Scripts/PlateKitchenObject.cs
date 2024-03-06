using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField, Required] private OnIngredientAddedEvent m_onIngredientAddedEvent;

    [SerializeField] private List<KitchenObjectSO> m_validKitchenSOList;
    List<KitchenObjectSO> m_kitchenObjectSOList = new List<KitchenObjectSO>();
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!m_validKitchenSOList.Contains(kitchenObjectSO))
        {
            return false;
        }


        if(m_kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        }

        m_kitchenObjectSOList.Add(kitchenObjectSO);
        m_onIngredientAddedEvent?.Raise(new OnIngredientAddedEvent.EventArgs(this, kitchenObjectSO));
        return true;
    }

    public List<KitchenObjectSO> GetKitchenObjectSOs()
    {
        return m_kitchenObjectSOList;
    }

}
