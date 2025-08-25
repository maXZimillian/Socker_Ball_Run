using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            ExecuteEvents.Execute<IBallModel>(other.gameObject, null, (x, y) => x.OnCheckpointEnter());
            GetComponent<Collider>().enabled=false;
        }
    }
}

