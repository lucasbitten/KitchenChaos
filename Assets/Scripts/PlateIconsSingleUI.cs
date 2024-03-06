using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateIconsSingleUI : MonoBehaviour
{
    [SerializeField, Required] Image m_ingredientIcon;

    public void SetKitchenObjectSO(KitchenObjectSO kitchenObjectSO)
    {
        m_ingredientIcon.sprite = kitchenObjectSO.IconSprite;
    }

}
