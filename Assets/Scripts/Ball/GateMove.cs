using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateMove : MonoBehaviour
{
    [SerializeField] private float penaltyAwaiting = 1.7f;
    private TouchHandler th;
    public TouchHandler touchHandler
    {
        get { return th; }
        set
        {
            th = value; AssignTouchHandler();
        }
    }
    private bool assigned = false;
    private Rigidbody body;
    public event Action OnSwiped;
    private Coroutine blockMovingCoroutine;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        GameObject.FindObjectOfType<GameController>().OnEnterSwipeArea += StopMove;
    }
    private void AssignTouchHandler()
    {
        if (!assigned)
        {
            th.OnSwipe += OnSwipe;
            assigned = true;
        }
    }

    private void StopMove()
    {
        if (blockMovingCoroutine != null)
            StopCoroutine(blockMovingCoroutine);
        blockMovingCoroutine = StartCoroutine(BlockMoving());
    }
    
    private IEnumerator BlockMoving()
    {
        while (true)
        {
            body.velocity = Vector3.zero;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnSwipe(Vector2[] swipeCoords)
    {
        Vector3[] simpleCoords = SimplifySwipeLine(swipeCoords);
        if (simpleCoords != null)
        {
            StartCoroutine(MoveToGate(simpleCoords));
            if (blockMovingCoroutine != null)
            {
                StopCoroutine(blockMovingCoroutine);
                blockMovingCoroutine = null;
            }
        }
        }

    private Vector3[] SimplifySwipeLine(Vector2[] swipeLine)
    {
        Vector3[] simplify = new Vector3[swipeLine.Length];
        for (int i = 0; i < swipeLine.Length; i++)
        {
            simplify[i] = new Vector3(swipeLine[i].x, swipeLine[i].y, 0f);
        }
        if (simplify.Length >= 5)
        {
            Vector3[] simpleCoords = new Vector3[5];
            simpleCoords[0] = simplify[0];
            simpleCoords[1] = simplify[(int)(simplify.Length * 0.4f)];
            simpleCoords[2] = simplify[(int)(simplify.Length * 0.5f)];
            simpleCoords[3] = simplify[(int)(simplify.Length * 0.8f)];
            simpleCoords[4] = simplify[simplify.Length - 1];
            return simpleCoords;
        }
        else
            return null;

    }

    private IEnumerator MoveToGate(Vector3[] moveCoords)
    {   
        body.velocity = Vector3.zero;
        float startPosition = transform.position.z;
        if(moveCoords[1].y>moveCoords[0].y&&moveCoords[2].y>moveCoords[1].y){//if swiped up
            OnSwiped?.Invoke(); 
            body.velocity = Vector3.zero;
            yield return new WaitForSeconds(penaltyAwaiting);
            float forceMultiplier = 2000f;
            Vector3 movement = new Vector3((moveCoords[2].x-moveCoords[0].x)*0.5f,0.0f,moveCoords[2].y-moveCoords[0].y)*forceMultiplier;
            if(Mathf.Sqrt(movement.z*movement.z+movement.x*movement.x)>16f){
                movement*=16f/Mathf.Sqrt(movement.z*movement.z+movement.x*movement.x);
            }
            movement.Set(movement.x,7f,movement.z);
            if(movement.x>4.5f)movement.Set(5f,7f,15f);
            if(movement.x<-4.5f)movement.Set(-5f,7f,15f);
            StartCoroutine(SideSpinMove(moveCoords,startPosition));
            body.velocity = movement;  
        }
    }

    private IEnumerator SideSpinMove(Vector3[] moveCoords, float startPosition)
    {
        yield return new WaitForSeconds(0.5f);
        float forceMultiplier = 100f;
        Vector3 movement = new Vector3(moveCoords[4].x-moveCoords[3].x,moveCoords[4].y-moveCoords[3].y,0.0f)*forceMultiplier;
        if(Mathf.Sqrt(movement.x*movement.x+movement.y*movement.y)>9f){
            movement*=9f/Mathf.Sqrt(movement.x*movement.x+movement.y*movement.y);
        }
        if(movement.y>1f)
            movement = new Vector3(movement.x,1f,movement.z);
        Vector3 tempVelocity = body.velocity;
        float addingX = (movement.x-tempVelocity.x)/30f;
        float addingY = (movement.y-tempVelocity.y)/30f;
        while(Mathf.Abs(tempVelocity.x-movement.x)>0.5f||Mathf.Abs(tempVelocity.y-movement.y)>0.5f){

            tempVelocity += new Vector3(addingX,addingY,0.0f);
            tempVelocity.z = body.velocity.z;
            body.velocity = tempVelocity;
            yield return new WaitForFixedUpdate();
        }
    }
}
