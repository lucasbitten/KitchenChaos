using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IHasProgress
{
    [SerializeField, Required] private OnProgressChangedEvent m_onProgressChangedEvent;
    [SerializeField, Required] private GameEvent_BaseCounter m_onCutEvent;
    [SerializeField] private List<CuttingRecipeSO> m_cuttingRecipes = new List<CuttingRecipeSO>();

    private int m_cuttingProgress;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                //if(HasRecipeWithInput(player.GetKitchenObject().KitchenObjectSO))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    m_cuttingProgress = 0;

                    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().KitchenObjectSO);
                    if(cuttingRecipeSO != null )
                    {
                        var args = new OnProgressChangedEvent.EventArgs(this, m_cuttingProgress / (float) cuttingRecipeSO.CuttingProgressMax);
                        m_onProgressChangedEvent?.Raise(args);
                    }
                }
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject() is PlateKitchenObject plateKitchenObject)
                {
                    //Player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().KitchenObjectSO))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //Player is holding something else
                    if (GetKitchenObject() is PlateKitchenObject plateKitchen)
                    {
                        if (plateKitchen.TryAddIngredient(player.GetKitchenObject().KitchenObjectSO))
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

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {
            var outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().KitchenObjectSO);
            if(outputKitchenObjectSO != null)
            {
                m_cuttingProgress++;
                m_onCutEvent?.Raise(this);

                CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().KitchenObjectSO);

                var args = new OnProgressChangedEvent.EventArgs(this, m_cuttingProgress / (float)cuttingRecipeSO.CuttingProgressMax);
                m_onProgressChangedEvent?.Raise(args);

                if (cuttingRecipeSO != null && m_cuttingProgress >= cuttingRecipeSO.CuttingProgressMax)
                {
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
                }

            }            
        }
    }

    //private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    //{
    //    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
    //    return cuttingRecipeSO != null;
    //}

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if(cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.Output;
        }

        return null;
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (var recipe in m_cuttingRecipes)
        {
            if (recipe.Input == inputKitchenObjectSO)
            {
                return recipe;
            }
        }
        return null;
    }

}
