using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinTrigger : MonoBehaviour
{
    public event Action<Vector2> OnWinEnter;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            Vector2 entryPoint = new Vector2(other.transform.position.x-transform.position.x,other.transform.position.y-transform.position.y);
            OnWinEnter?.Invoke(entryPoint);
            GetComponent<Collider>().enabled=false;
        }
    }
}


