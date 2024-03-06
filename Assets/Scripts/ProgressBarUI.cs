using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField, Required] private Image m_barImage;
    [SerializeField, Required] private CuttingCounter m_cuttingCounter;
    [SerializeField, Required] private OnCuttingProgressChangedEvent m_onCuttingProgressChangedEvent;


    private void Start()
    {
        m_onCuttingProgressChangedEvent.EventListeners += OnCuttingProgressChangedEvent_EventListeners;
        m_barImage.fillAmount = 0;
        Hide();
    }

    private void OnCuttingProgressChangedEvent_EventListeners(OnCuttingProgressChangedEvent.EventArgs args)
    {
        if(m_cuttingCounter == args.CuttingCounter)
        {
            m_barImage.fillAmount = args.ProgressNormalized;

            if(args.ProgressNormalized == 0 || args.ProgressNormalized == 1)
            {
                Hide();
            }
            else
            {
                Show();
            }

        }
    }

    private void OnDestroy()
    {
        m_onCuttingProgressChangedEvent.EventListeners -= OnCuttingProgressChangedEvent_EventListeners;
    }

    private void Show()
    {
        gameObject.SetActive(true);

    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
