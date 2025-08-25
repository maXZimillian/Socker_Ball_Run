using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyPlayerController : MonoBehaviour
{
    private Animator animator;

    private void Start() 
    {
        GateMove ball = GameObject.FindObjectOfType<GateMove>();
        ball.OnSwiped +=StartAnimation;
        animator = GetComponent<Animator>();
    }

    private void StartAnimation() 
    {
        animator.SetTrigger("ballHit");
    }
}
