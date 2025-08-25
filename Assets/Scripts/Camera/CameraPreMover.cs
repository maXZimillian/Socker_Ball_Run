using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CameraPreMover : MonoBehaviour
{
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private float destinationPoint;
    [SerializeField] private GameObject[] followingListeners;
    private Rigidbody body;

    void Start()
    {
        if(followingListeners.Length==0)
        {
            followingListeners = new GameObject[1];
            followingListeners[0] = GameObject.FindObjectOfType<Follow>().gameObject;
        }
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(transform.position.z<=destinationPoint){
            foreach(GameObject listener in followingListeners)
                ExecuteEvents.Execute<IFollowing>(listener,null,(x,y) => x.ChangeTarget());
            Destroy(gameObject);
        }
        Vector3 movement = new Vector3(0.0f, 0.0f, -1f);
        body.AddForce((movement * speed)-new Vector3(0.0f,0.0f,body.velocity.z),ForceMode.VelocityChange);
    }
}
