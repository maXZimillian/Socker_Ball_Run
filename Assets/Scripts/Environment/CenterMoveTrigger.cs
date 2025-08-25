using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMoveTrigger : MonoBehaviour
{
    private Coroutine dragCoroutine;
    public delegate void Collide();
    public event Collide OnEnter;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            OnEnter?.Invoke();
            Rigidbody ballBody = other.GetComponent<Rigidbody>();
            if(dragCoroutine!=null)
                StopCoroutine(dragCoroutine);
            dragCoroutine = StartCoroutine(DragToCenter(other.gameObject,ballBody));
        }
    }

    private IEnumerator DragToCenter(GameObject ball,Rigidbody ballBody)
    {
        float maxMultiplier = 1.8f;
        while(Mathf.Abs(ball.transform.position.x)>0.1f)
        {
            float forceMultiplier = Mathf.Abs(ball.transform.position.x-0f)*5f;
            forceMultiplier = forceMultiplier>maxMultiplier?maxMultiplier:forceMultiplier;
            Vector3 direction = ball.transform.position.x-0f>0?Vector3.left:Vector3.right;
            ballBody.AddForce((direction * forceMultiplier)-new Vector3(ballBody.velocity.x,0.0f,0.0f),ForceMode.VelocityChange);         
            yield return new WaitForFixedUpdate();
        }
        ballBody.AddForce(new Vector3(-ballBody.velocity.x/Time.fixedDeltaTime*ballBody.mass,0.0f,0.0f),ForceMode.Force);
        ballBody.angularVelocity = new Vector3(ballBody.angularVelocity.x, ballBody.angularVelocity.y, 0);
        yield return null;
    }
}
