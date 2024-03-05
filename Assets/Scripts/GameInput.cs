using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnInteractAction;

    private PlayerInputActions m_playerInputActions;
    private void Awake()
    {
        m_playerInputActions = new PlayerInputActions();
        m_playerInputActions.Player.Enable();

        m_playerInputActions.Player.Interact.performed += OnInteractPerformed;

    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);   
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = m_playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
