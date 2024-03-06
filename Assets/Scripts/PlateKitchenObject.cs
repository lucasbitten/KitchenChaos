using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
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
        return true;
    }
}
