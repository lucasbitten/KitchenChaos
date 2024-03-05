using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;

[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    [field: SerializeField] public GameObject Prefab { get; private set;}
    [field: SerializeField] public Sprite IconSprite { get; private set; }
    [field: SerializeField] public string ObjectName { get; private set; }


}
