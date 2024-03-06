using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{

    private const string CUT = "Cut";

    [SerializeField, Required] private CuttingCounter m_counter;
    [SerializeField, Required] private Animator m_animator;
    [SerializeField, Required] private GameEvent_BaseCounter m_onCutEvent;


    private void Start()
    {
        m_onCutEvent.EventListeners += OnCut;
    }

    private void OnCut(BaseCounter counter)
    {
        if(counter == m_counter)
        {
            m_animator.SetTrigger(CUT);
        }
    }
}
