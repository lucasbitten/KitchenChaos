using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField, Required] private PlatesCounter m_platesCounter;
    [SerializeField, Required] private Transform m_counterTopPoint;
    [SerializeField, Required] private GameObject m_plateVisualPrefab;
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlateSpawnedEvent;
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlateRemovedEvent;

    [SerializeField, Required] private float m_plateOffsetY = 0.1f;

    private List<GameObject> m_plateVisualGameObjectList = new List<GameObject>();

    private void Start()
    {
        m_onPlateSpawnedEvent.EventListeners += OnPlateSpawnedEvent_EventListeners;
        m_onPlateRemovedEvent.EventListeners += OnPlateRemoved_EventListeners;
    }

    private void OnPlateRemoved_EventListeners(BaseCounter counter)
    {
        var plateGameObject = m_plateVisualGameObjectList[m_plateVisualGameObjectList.Count - 1];
        m_plateVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void OnPlateSpawnedEvent_EventListeners(BaseCounter counter)
    {
        if(counter == m_platesCounter)
        {
            var plateVisual = Instantiate(m_plateVisualPrefab, m_counterTopPoint);
            plateVisual.transform.localPosition = new Vector3(0, m_plateVisualGameObjectList.Count * m_plateOffsetY, 0);
            m_plateVisualGameObjectList.Add(plateVisual);
        }
    }

}
