using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField, Required] private Image m_barImage;
    [SerializeField, Required] private GameObject m_hasProgressGameObject;
    [SerializeField, Required] private OnProgressChangedEvent m_onCuttingProgressChangedEvent;

    private IHasProgress m_hasProgress;
    private void Start()
    {
        m_hasProgress = m_hasProgressGameObject.GetComponent<IHasProgress>();
        if(m_hasProgress == null)
        {
            Debug.LogError($"GameObject {m_hasProgressGameObject} does not have a component that implements IHasProgress");
        }
        m_onCuttingProgressChangedEvent.EventListeners += OnProgressChangedEvent_EventListeners;
        m_barImage.fillAmount = 0;
        Hide();
    }

    private void OnProgressChangedEvent_EventListeners(OnProgressChangedEvent.EventArgs args)
    {
        if(m_hasProgress == args.HasProgress)
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
        m_onCuttingProgressChangedEvent.EventListeners -= OnProgressChangedEvent_EventListeners;
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
