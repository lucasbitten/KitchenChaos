using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [System.Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject GameObject;
    }


    [SerializeField, Required] private OnIngredientAddedEvent m_onIngredientAddedEvent;
    [SerializeField, Required] private PlateKitchenObject m_plateKitchenObject;
    [SerializeField] List<KitchenObjectSO_GameObject> m_kitchenObjectSOGameObjectsList = new List<KitchenObjectSO_GameObject>();

    private void Start()
    {
        m_onIngredientAddedEvent.EventListeners += OnIngredientAddedEvent_EventListeners;
        foreach (var item in m_kitchenObjectSOGameObjectsList)
        {
            item.GameObject.SetActive(false);
        }
    }

    private void OnIngredientAddedEvent_EventListeners(OnIngredientAddedEvent.EventArgs args)
    {
        if(args.Plate == m_plateKitchenObject)
        {
            foreach (var item in m_kitchenObjectSOGameObjectsList)
            {
                if(item.KitchenObjectSO == args.Ingredient)
                {
                    item.GameObject.SetActive(true);
                }
            }
        }
    }
}
