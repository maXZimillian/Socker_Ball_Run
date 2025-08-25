using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] GameObject checkpointPlayer;
    [SerializeField] Rigidbody player;
    [SerializeField] float triggerPosMultiplier = 0.21f;
    private Animator animator;

    private void Start() 
    {
        animator = checkpointPlayer.GetComponent<Animator>();
        if(player==null)player = GameObject.FindObjectOfType<BallController>().gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        transform.localScale = new Vector3(player.velocity.z*triggerPosMultiplier,player.velocity.z*triggerPosMultiplier,player.velocity.z*triggerPosMultiplier);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("ballHit");
        }
    }
}
