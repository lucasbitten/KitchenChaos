using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlateSpawnedEvent;
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlateRemovedEvent;
    [SerializeField, Required] private KitchenObjectSO m_plateKitchenObjectSO;
    [SerializeField] private float m_spawnPlateTimerMax = 4f;
    [SerializeField] private int m_platesSpawnedAmountMax = 4;
    private float m_spawnPlateTimer;
    private int m_platesSpawnedAmount;


    private void Update()
    {
        m_spawnPlateTimer += Time.deltaTime;
        if(m_spawnPlateTimer > m_spawnPlateTimerMax)
        {
            m_spawnPlateTimer = 0;
            if(m_platesSpawnedAmount < m_spawnPlateTimerMax)
            {
                m_platesSpawnedAmount++;
                m_onPlateSpawnedEvent?.Raise(this);
            }
        }
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            if(m_platesSpawnedAmount > 0)
            {
                m_platesSpawnedAmount--;
                KitchenObject.SpawnKitchenObject(m_plateKitchenObjectSO, player);
                m_onPlateRemovedEvent?.Raise(this);
            }
        }
    }
}
