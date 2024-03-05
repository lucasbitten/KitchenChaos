using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{

    private const string OPEN_CLOSE = "OpenClose";

    [SerializeField, Required] BaseCounter m_counter;
    [SerializeField, Required] Animator m_animator;
    [SerializeField, Required] private GameEvent_BaseCounter m_onPlayerGrabbedObjectFromCounter;


    private void Start()
    {
        m_onPlayerGrabbedObjectFromCounter.EventListeners += OnPlayerGrabbedObjectFromCounter;
    }

    private void OnPlayerGrabbedObjectFromCounter(BaseCounter counter)
    {
        if(counter == m_counter)
        {
            m_animator.SetTrigger(OPEN_CLOSE);
        }
    }
}
