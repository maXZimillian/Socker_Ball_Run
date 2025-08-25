using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRotateConsumer : MonoBehaviour
{
    private Quaternion startRotation;
    private void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = startRotation;
    }

}
