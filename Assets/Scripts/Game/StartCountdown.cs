using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class StartCountdown : MonoBehaviour
{
    [SerializeField] int secondsCount;
       
    public event Action<int> OnChangeDelay;
    public event Action OnDelayEnd;

    private void Start()
    {
        StartCoroutine(DownCounter());
    }
    
    private IEnumerator DownCounter(){

        while(secondsCount>=0){ 
            OnChangeDelay?.Invoke(secondsCount--);      
            yield return new WaitForSeconds(1);
        }
            OnDelayEnd?.Invoke();
        BallController ball = GameObject.FindObjectOfType<BallController>();
        ball.StartMove();
        Destroy(this);
    }
}
