using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 pointerDownPosition;
    private Vector2[] swipeCoords;
    private int controlType = -1;
    private Coroutine swipeCoroutine;

    public event Action OnTouchEnd;
    public event Action<Vector2[]> OnSwipe;
    public event Action<Vector2> OnDragStart;
    public event Action OnDragEnd;

    private void Start() {
        StartCountdown downCounter = GameObject.FindObjectOfType<StartCountdown>();
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.OnEnterSwipeArea += ChangeControlToSwipe;
        gameController.OnSwipeExit += BlockControl;
        downCounter.OnDelayEnd +=ChangeControlToDrag;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

            pointerDownPosition = new Vector2(eventData.position.x, eventData.position.y);
            if(controlType==1)
            {
                OnDragStart?.Invoke(pointerDownPosition);
            }
            if(controlType==0)
            {
                if(swipeCoroutine!=null)
                    StopCoroutine(swipeCoroutine);
                swipeCoroutine = StartCoroutine(BuildSwipeLine());
            }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(controlType==0){
            OnSwipeEnd();
            if(swipeCoroutine!=null)
                StopCoroutine(swipeCoroutine);
            swipeCoroutine = null;

        }
        if(controlType==1)
        {
            OnDragEnd?.Invoke();
        }
        OnTouchEnd?.Invoke();
    }

    private void BlockControl()
    {
        controlType = -1;
    }

    private void ChangeControlToSwipe()
    {
        controlType = 0;
    }

    private void ChangeControlToDrag()
    {
        controlType = 1;
    }

    private void OnSwipeEnd()
    {
        if(swipeCoords!=null)OnSwipe?.Invoke(swipeCoords);
    }

    private IEnumerator BuildSwipeLine()
    {   
        swipeCoords = new Vector2[0];
        while(true){
            float distanceBetweenPoints = 0;
            if(swipeCoords.Length>0)
                distanceBetweenPoints = Mathf.Sqrt(Mathf.Pow((Input.mousePosition.x/Screen.height*3f-swipeCoords[swipeCoords.Length-1].x),2f)+
                Mathf.Pow((Input.mousePosition.y/Screen.height*3f-swipeCoords[swipeCoords.Length-1].y),2f));

            if(swipeCoords.Length==0||distanceBetweenPoints>0.1f){
                Array.Resize(ref swipeCoords,swipeCoords.Length+1);
                swipeCoords[swipeCoords.Length-1] = new Vector2(Input.mousePosition.x/Screen.height*3f,Input.mousePosition.y/Screen.height*3f);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}


