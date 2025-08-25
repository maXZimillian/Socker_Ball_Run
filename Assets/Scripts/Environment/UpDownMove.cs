using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    private float downPosition;
    private float time = 0f;
    void Start()
    {
        downPosition = transform.position.y+0.3f;
        //transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }
    
    private void Update() {
        time += Time.unscaledDeltaTime*8;
        transform.position = new Vector3(transform.position.x,downPosition+Mathf.Sin(time)/5f,transform.position.z);
    }


}
