using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyGoalkeeperStrike : MonoBehaviour
{
    private Animator animator;
    

    private void Start() 
    {
        StartCountdown counterInstance = GameObject.FindObjectOfType<StartCountdown>();
        counterInstance.OnChangeDelay+= AwaitForStrike;
        animator = GetComponent<Animator>();
    }

    public void AwaitForStrike(int seconds) 
    {
        if(seconds == 0)
            animator.SetTrigger("strike");
    }
}
