using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;

[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    [field: SerializeField, Required] public GameObject Prefab { get; private set;}
    [field: SerializeField, Required] public Sprite IconSprite { get; private set; }
    [field: SerializeField, Required] public string ObjectName { get; private set; }
}
