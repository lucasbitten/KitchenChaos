using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField, Required] protected KitchenObjectSO m_kitchenObjectSO;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            if(player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            if(player.HasKitchenObject())
            {
                if(player.GetKitchenObject() is PlateKitchenObject plateKitchenObject)
                {
                    //Player is holding a plate
                    if(plateKitchenObject.TryAddIngredient(GetKitchenObject().KitchenObjectSO))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //Player is holding something else
                    if(GetKitchenObject() is PlateKitchenObject plateKitchen)
                    {
                        if(plateKitchen.TryAddIngredient(player.GetKitchenObject().KitchenObjectSO))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }

                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
