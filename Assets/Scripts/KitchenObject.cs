using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [field: SerializeField, RequiredIn(PrefabKind.PrefabInstance)] public KitchenObjectSO KitchenObjectSO { get; private set; }
    private IKitchenObjectParent m_kitchenObjectParent;

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.m_kitchenObjectParent != null)
        {
            this.m_kitchenObjectParent.ClearKitchenObject();
        }

        this.m_kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a KitchenObject");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }


    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return m_kitchenObjectParent;
    }

    public void DestroySelf()
    {
        m_kitchenObjectParent.ClearKitchenObject();
        Destroy(this.gameObject);
    }



    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        var kitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab);
        if (kitchenObjectTransform.TryGetComponent(out KitchenObject kitchenObject))
        {
            kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
        }
        return kitchenObject;
    }

}
