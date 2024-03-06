using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField, Required] private PlateKitchenObject m_plateKitchenObject;
    [SerializeField, Required] private OnIngredientAddedEvent m_onIngredientAddedEvent;
    [SerializeField, Required] private GameObject m_iconPrefab;


    private void Start()
    {
        m_onIngredientAddedEvent.EventListeners += OnIngredientAddedEvent_EventListeners;

    }

    private void OnIngredientAddedEvent_EventListeners(OnIngredientAddedEvent.EventArgs args)
    {
        if (args.Plate == m_plateKitchenObject)
        {
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        foreach (var kitchenObjectSO in m_plateKitchenObject.GetKitchenObjectSOs())
        {
            var iconGO = Instantiate(m_iconPrefab, transform);
            if(iconGO != null && iconGO.TryGetComponent(out PlateIconsSingleUI plateIconsSingleUI))
            {
                plateIconsSingleUI.SetKitchenObjectSO(kitchenObjectSO);
            }
        }
    }

}
