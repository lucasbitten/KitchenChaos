using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress
{
    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }

    [SerializeField, Required] private OnStoveStateChangedEvent m_onStoveStateChangedEvent;
    [SerializeField, Required] private OnProgressChangedEvent m_onProgressChangedEvent;
    [SerializeField] private List<FryingRecipeSO> m_fryingRecipes = new List<FryingRecipeSO>();
    [SerializeField] private List<BurningRecipeSO> m_burningRecipes = new List<BurningRecipeSO>();

    private State m_state = State.Idle;
    private float m_fryingTimer;
    private float m_burningTimer;
    FryingRecipeSO m_fryingRecipeSO;
    BurningRecipeSO m_burningRecipeSO;

    private void Start()
    {
        ChangeState(State.Idle);
    }

    private void Update()
    {
        if(HasKitchenObject())
        {
            switch (m_state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                    m_fryingTimer += Time.deltaTime;
                    m_onProgressChangedEvent?.Raise(new OnProgressChangedEvent.EventArgs(this, m_fryingTimer / m_fryingRecipeSO.FryingTimerMax));

                    if (m_fryingRecipeSO != null && m_fryingTimer > m_fryingRecipeSO.FryingTimerMax)
                    {
                        //Fried
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(m_fryingRecipeSO.Output, this);

                        m_burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().KitchenObjectSO);
                        ChangeState(State.Fried);
                        m_burningTimer = 0;
                    }
                    break;
                case State.Fried:
                    m_burningTimer += Time.deltaTime;
                    m_onProgressChangedEvent?.Raise(new OnProgressChangedEvent.EventArgs(this, m_burningTimer / m_burningRecipeSO.BurningTimerMax));

                    if (m_burningRecipeSO != null && m_burningTimer > m_burningRecipeSO.BurningTimerMax)
                    {
                        //Fried
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(m_burningRecipeSO.Output, this);
                        ChangeState(State.Burned);

                        m_onProgressChangedEvent?.Raise(new OnProgressChangedEvent.EventArgs(this, 0f));

                    }
                    break;
                case State.Burned:
                    break;
                default:
                    break;
            }
        }
    }

    void ChangeState(State state)
    {
        m_state = state;
        m_onStoveStateChangedEvent.Raise(new OnStoveStateChangedEvent.EventArgs(this, m_state));
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if(HasRecipeWithInput(player.GetKitchenObject().KitchenObjectSO))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    m_fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().KitchenObjectSO);
                    ChangeState(State.Frying);
                    m_fryingTimer = 0;

                    m_onProgressChangedEvent?.Raise(new OnProgressChangedEvent.EventArgs(this, m_fryingTimer / m_fryingRecipeSO.FryingTimerMax));

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
                        ChangeState(State.Idle);
                        m_onProgressChangedEvent?.Raise(new OnProgressChangedEvent.EventArgs(this, 0f));
                    }
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
                ChangeState(State.Idle);
                m_onProgressChangedEvent?.Raise(new OnProgressChangedEvent.EventArgs(this, 0f));

            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.Output;
        }

        return null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (var recipe in m_fryingRecipes)
        {
            if (recipe.Input == inputKitchenObjectSO)
            {
                return recipe;
            }
        }
        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (var recipe in m_burningRecipes)
        {
            if (recipe.Input == inputKitchenObjectSO)
            {
                return recipe;
            }
        }
        return null;
    }
}
