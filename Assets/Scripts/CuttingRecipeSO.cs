using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    [field: SerializeField, Required] public KitchenObjectSO Input { get; private set; }
    [field: SerializeField, Required] public KitchenObjectSO Output { get; private set; }
    [field: SerializeField, Required] public int CuttingProgressMax { get; private set; }

}
