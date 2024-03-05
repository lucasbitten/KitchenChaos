using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{

    private const string IS_WALKING = "IsWalking";

    [SerializeField] Animator m_animator;
    [SerializeField] Player m_player;


    private void Update()
    {
        m_animator.SetBool(IS_WALKING, m_player.IsWalking());
    }

}
