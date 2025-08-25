using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Obstacle : MonoBehaviour
{
    public delegate void Collide();
    public event Collide OnObstacleHit;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            GetComponent<Collider>().enabled=false;
            ExecuteEvents.Execute<IBallModel>(other.gameObject,null,(x,y) => x.OnObstacleCollide());
            OnObstacleHit?.Invoke();
        }
    }
}
