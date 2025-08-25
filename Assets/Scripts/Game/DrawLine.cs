using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DrawLine : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public LineRenderer lineRenderer;
    private Vector3[] positions;
    private Coroutine drawingLineCoroutine;
    private bool draw = false;

    private void Start() {
        positions = new Vector3[0];
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.OnEnterSwipeArea +=AllowDrawing;
        gameController.OnSwipeExit += DisallowDrawing;
    }

    private void AllowDrawing(){
        draw = true;
    }

    private void DisallowDrawing(){
        draw = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
            if(draw){
                positions=new Vector3[0];
                if(drawingLineCoroutine!=null)
                    StopCoroutine(drawingLineCoroutine);
                drawingLineCoroutine = StartCoroutine(DrawingLine());
            }

    }

    private IEnumerator DrawingLine(){
        lineRenderer.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        while(true)
        {
           // Debug.Log(Input.mousePosition);
            Array.Resize(ref positions,positions.Length+1);
            positions[positions.Length-1]=new Vector3((Input.mousePosition.x-Screen.width/2f)/Screen.height*2.3f,(Input.mousePosition.y-Screen.height/2f)/Screen.height*2.3f,0.0f);
            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);
            yield return new WaitForEndOfFrame();
        }
    }
    private IEnumerator HideLine(){
        float alpha = lineRenderer.GetComponent<Renderer>().material.color.a;
        while(alpha>0f)
        {
            alpha-= Time.unscaledDeltaTime;
            lineRenderer.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, alpha));
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(drawingLineCoroutine!=null)
            StopCoroutine(drawingLineCoroutine);
        drawingLineCoroutine = StartCoroutine(HideLine());

    }
}

