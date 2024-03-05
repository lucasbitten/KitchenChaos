using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField, Required] private BaseCounter m_counter;
    [SerializeField, Required] private List<GameObject> m_selectedVisuals = new List<GameObject>();
    [SerializeField, Required, FoldoutGroup("Game Events")] private GameEvent_BaseCounter m_counterSelectedEvent;


    private void Awake()
    {
        m_counterSelectedEvent.EventListeners += OnCounterSelected;
    }

    private void OnCounterSelected(BaseCounter counter)
    {
        if(counter == m_counter)
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
        foreach (var visual in m_selectedVisuals)
        {
            visual.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (var visual in m_selectedVisuals)
        {
            visual.SetActive(false);
        }
    }


}
