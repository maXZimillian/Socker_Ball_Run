using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    [SerializeField] GameObject checkpointPlayer;
    [SerializeField] float maxJumpDistance = 2.3f;
    [SerializeField] Rigidbody player;
    private Animator animator;

    private void Start() 
    {
        animator = checkpointPlayer.GetComponent<Animator>();
        if(player==null)player = GameObject.FindObjectOfType<BallController>().gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeAnimation(other.gameObject);
            GetComponent<Collider>().enabled=false;
        }
    }

    private void ChangeAnimation(GameObject other)
    {
        Vector3 ballVelocity = other.GetComponent<Rigidbody>().velocity;
        Vector3 ballOffset = new Vector3(other.transform.position.x-checkpointPlayer.transform.position.x, other.transform.position.y-checkpointPlayer.transform.position.y,checkpointPlayer.transform.position.z-other.transform.position.z);
        Vector2 jumpOffset = new Vector2(ballOffset.x+ballVelocity.x/ballVelocity.z*5f,ballOffset.y+ballVelocity.y/ballVelocity.z*5f/*-ballOffset.z/ballVelocity.z*/);
        if(jumpOffset.x>maxJumpDistance)jumpOffset = new Vector2(maxJumpDistance,jumpOffset.y);
        else
        if(jumpOffset.x<-maxJumpDistance)jumpOffset = new Vector2(-maxJumpDistance,jumpOffset.y);
        Vector3 movement = new Vector3(jumpOffset.x*2f,jumpOffset.y*2f,0.0f);
        BoxCollider col = checkpointPlayer.GetComponent<BoxCollider>();

        if(jumpOffset.y>1.5f&&Mathf.Abs(jumpOffset.x)<1.1f)
        {
            animator.SetTrigger("Jump");
            checkpointPlayer.GetComponent<Rigidbody>().AddForce(movement,ForceMode.VelocityChange);
        }else
        if(jumpOffset.y>1.5f&&Mathf.Abs(jumpOffset.x)>=1.1f)
        {        
            col.size = new Vector3(col.size.y,col.size.x,col.size.z);
            movement = new Vector3(jumpOffset.x*2.3f,jumpOffset.y*2.1f,0.0f);
            if(jumpOffset.x>0)
                animator.SetTrigger("RightDive");
            else
                animator.SetTrigger("LeftDive");
            checkpointPlayer.GetComponent<Rigidbody>().AddForce(movement,ForceMode.VelocityChange);            
        }else
        if(jumpOffset.y<=1.5f&&Mathf.Abs(jumpOffset.x)>0.0f)
        {
            col.size = new Vector3(col.size.y,col.size.x,col.size.z);
            col.center= new Vector3(col.center.x,0.49f,col.center.z);
            if(jumpOffset.x>0)
                animator.SetTrigger("RightBlock");
            else
                animator.SetTrigger("LeftBlock");
            StartCoroutine(WalkToBall(jumpOffset));
                       
        }


    }

    private IEnumerator WalkToBall(Vector3 distance)
    {
        float destPoint = checkpointPlayer.transform.position.x+distance.x;
        Vector3 movement = distance.x>0f? Vector3.right*2.2f:Vector3.left*2.2f;
        while(destPoint>checkpointPlayer.transform.position.x&&distance.x>0f||destPoint<checkpointPlayer.transform.position.x&&distance.x<0f)
        {
            checkpointPlayer.GetComponent<Rigidbody>().velocity = movement; 
            if(Mathf.Abs(destPoint-checkpointPlayer.transform.position.x)<=2f)
                animator.SetTrigger("EndBlock");
            yield return new WaitForFixedUpdate();
        }
        checkpointPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
