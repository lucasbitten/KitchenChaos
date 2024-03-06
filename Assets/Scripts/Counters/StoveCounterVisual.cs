using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField, Required] private StoveCounter m_counter;
    [SerializeField, Required] private OnStoveStateChangedEvent m_onStoveStateChangedEvent;
    [SerializeField, Required] private GameObject m_stoveOnGameObject;
    [SerializeField, Required] private GameObject m_particlesGameObject;

    private void Start()
    {
        m_onStoveStateChangedEvent.EventListeners += OnStoveStateChangedEvent_EventListeners;
    }

    private void OnStoveStateChangedEvent_EventListeners(OnStoveStateChangedEvent.EventArgs args)
    {
        if(m_counter == args.StoveCounter)
        {
            bool showVisual = args.State == StoveCounter.State.Frying || args.State == StoveCounter.State.Fried;
            m_stoveOnGameObject.SetActive(showVisual);
            m_particlesGameObject.SetActive(showVisual);
        }
    }
}
