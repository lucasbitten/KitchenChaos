using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField, Required] private ClearCounter m_counter;
    [SerializeField, Required] private GameObject m_selectedVisual;
    [SerializeField, Required, FoldoutGroup("Game Events")] private CounterSelectedEvent m_counterSelectedEvent;


    private void Awake()
    {
        m_counterSelectedEvent.EventListeners += OnCounterSelected;
    }

    private void OnCounterSelected(CounterSelectedEvent.Args args)
    {
        if(args.Counter == m_counter)
        {
            Show();
        }   
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        Debug.Log($"Counter Selected: {m_counter.name}");
        m_selectedVisual.SetActive(true);
    }

    private void Hide()
    {
        m_selectedVisual.SetActive(false);
    }


}
