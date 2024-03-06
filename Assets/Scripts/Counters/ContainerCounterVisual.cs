using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{

    private const string OPEN_CLOSE = "OpenClose";

    [SerializeField, Required] private ContainerCounter m_counter;
    [SerializeField, Required] private Animator m_animator;
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlayerGrabbedObjectFromCounterEvent;


    private void Start()
    {
        m_onPlayerGrabbedObjectFromCounterEvent.EventListeners += OnPlayerGrabbedObjectFromCounter;
    }

    private void OnPlayerGrabbedObjectFromCounter(BaseCounter counter)
    {
        if(counter == m_counter)
        {
            m_animator.SetTrigger(OPEN_CLOSE);
        }
    }
}
