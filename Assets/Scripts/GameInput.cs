using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    [SerializeField, Required, FoldoutGroup("Game Events")] private GameEvent m_onInteractAction;
    [SerializeField, Required, FoldoutGroup("Game Events")] private GameEvent m_onInteractAlternateAction;


    private PlayerInputActions m_playerInputActions;
    private void Awake()
    {
        m_playerInputActions = new PlayerInputActions();
        m_playerInputActions.Player.Enable();

        m_playerInputActions.Player.Interact.performed += OnInteractPerformed;
        m_playerInputActions.Player.InteractAlternate.performed += OnInteractAlternatePerformed;
    }

    private void OnInteractAlternatePerformed(InputAction.CallbackContext context)
    {
        m_onInteractAlternateAction.Raise();
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        m_onInteractAction.Raise();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = m_playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
