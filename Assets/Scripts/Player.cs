using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 7f;
    [SerializeField] private float m_rotationSpeed = 10f;
    [SerializeField] private GameInput m_playerInput;
    [SerializeField] private float m_playerRadius = 0.7f;
    [SerializeField] private float m_playerHeight = 2f;
    [SerializeField] private float m_interactionDistance = 2f;
    [SerializeField] private LayerMask m_countersLayerMask;


    private bool m_isWalking;
    private Vector3 m_lastInteractionDirection;
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void HandleInteractions() 
    {
        var inputVector = m_playerInput.GetMovementVectorNormalized();
        Vector3 moveDir = Vector3.zero;
        moveDir.x = inputVector.x;
        moveDir.z = inputVector.y;

        if(moveDir != Vector3.zero)
        {
            m_lastInteractionDirection = moveDir;
        }


        if(Physics.Raycast(transform.position, m_lastInteractionDirection, out RaycastHit raycastHit, m_interactionDistance, m_countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }

    }

    private void HandleMovement()
    {
        var inputVector = m_playerInput.GetMovementVectorNormalized();
        Vector3 moveDir = Vector3.zero;
        moveDir.x = inputVector.x;
        moveDir.z = inputVector.y;


        m_isWalking = moveDir != Vector3.zero;

        if (m_isWalking)
        {
            float moveDistance = m_moveSpeed * Time.deltaTime;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * m_playerHeight, m_playerRadius, moveDir, moveDistance);

            if (!canMove)
            {
                // Cannot move towards moveDir

                //Attempt only X movement
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * m_playerHeight, m_playerRadius, moveDirX, moveDistance);

                if (canMove)
                {
                    // Can move only on the X
                    moveDir = moveDirX;
                }
                else
                {
                    //Attempt only Z movement
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                    canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * m_playerHeight, m_playerRadius, moveDirZ, moveDistance);

                    if (canMove)
                    {
                        // Can move only on the Z
                        moveDir = moveDirZ;
                    }
                }
            }

            if (canMove)
            {
                transform.position += moveDir * moveDistance;
            }
        }
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * m_rotationSpeed);
    }

    public bool IsWalking()
    {
        return m_isWalking;
    }


}
