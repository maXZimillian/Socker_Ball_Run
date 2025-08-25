using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GoalGateTrigger : MonoBehaviour
{
    public delegate void EnterTrigger();
    public event EnterTrigger OnGateEnter;
    public event EnterTrigger OnGateExit;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            ExecuteEvents.Execute<IBallModel>(other.gameObject,null,(x,y)=>x.StopAcceleration());
            if(OnGateEnter!=null)OnGateEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(OnGateExit!=null)OnGateExit.Invoke();
            GetComponent<Collider>().enabled=false;
        }
    }
}


