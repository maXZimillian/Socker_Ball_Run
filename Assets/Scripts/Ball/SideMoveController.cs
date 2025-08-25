using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class SideMoveController : MonoBehaviour
{
    private TouchHandler th;
    public TouchHandler touchHandler 
    { 
        get { return th; } set 
        {
            th = value; AssignTouchHandler();
        }
    }
    private bool assigned = false;
    private Rigidbody objBody;
    private bool drag = false;
    private float dragStartPosition = 0f;
    private float moveDestinationPos = 0;
    private float offset = 0;
    private Coroutine dragCoroutine;

    private void Start() 
    {
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.OnBallCenterMove += ChangeControlType;
        objBody = GetComponent<Rigidbody>();
        dragCoroutine = StartCoroutine(MoveOnDrag());
    }

    private void AssignTouchHandler()
    {
        if (!assigned)
        {
            th.OnDragStart += OnDragStart;
            th.OnDragEnd += OnDragEnd;
            assigned = true;
        }
    }

    private void OnDragStart(Vector2 startPos)
    {
        drag = true;
        dragStartPosition = startPos.x;
        offset = transform.position.x;
    }

    private void OnDragEnd()
    {
        drag = false;
    }

    private void ChangeControlType(){
        if(dragCoroutine!=null)
        {
            StopCoroutine(dragCoroutine);
            dragCoroutine = null;
        }else
        {
            dragCoroutine=StartCoroutine(MoveOnDrag());
        }
    }

    IEnumerator MoveOnDrag()
    {
        Vector3 direction = Vector3.right;
        float maxMultiplier = 2.8f;
        float sensivity = 0.005f;
        while(true)
        {
            if(drag)
            {
                float pointerOffset = (Input.mousePosition.x-dragStartPosition)*sensivity+offset;
                moveDestinationPos = pointerOffset >= 1.0f ? 1.0f : (pointerOffset <= -1.0f ? -1.0f : pointerOffset);
            }

            if(Mathf.Abs(transform.position.x-moveDestinationPos)<=0.1f){
               objBody.AddForce(new Vector3(-objBody.velocity.x/Time.fixedDeltaTime* objBody.mass,0.0f,0.0f),ForceMode.Force);
               objBody.angularVelocity = new Vector3(objBody.angularVelocity.x, objBody.angularVelocity.y, 0);
            }
            else{
                float forceMultiplier = Mathf.Abs(transform.position.x-moveDestinationPos)*5f;
                forceMultiplier = forceMultiplier>maxMultiplier?maxMultiplier:forceMultiplier;
                direction = transform.position.x-moveDestinationPos>0?Vector3.left:Vector3.right;
                objBody.AddForce((direction * forceMultiplier)-new Vector3(objBody.velocity.x,0.0f,0.0f),ForceMode.VelocityChange);
            }
            
          yield return new WaitForFixedUpdate();
        }
    }

}