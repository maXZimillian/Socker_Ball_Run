using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public delegate void EnterTrigger();
    public event EnterTrigger OnEnter;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            ExecuteEvents.Execute<IBallModel>(other.gameObject,null,(x,y)=>x.StopAcceleration());
            if(OnEnter!=null)OnEnter.Invoke();
            GetComponent<Collider>().enabled=false;
        }
    }
}
