using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            GetComponent<Collider>().enabled=false;
            ExecuteEvents.Execute<IBallModel>(other.gameObject,null,(x,y) => x.OnKickUp());
        }
    }
}