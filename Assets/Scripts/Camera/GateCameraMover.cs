using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GateCameraMover : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smooth= 5.0f;
    [SerializeField] private GameObject[] followingListeners;
    private Coroutine followingCoroutine;

    void Start()
    {
        if (followingListeners.Length == 0)
        {
            followingListeners = new GameObject[1];
            followingListeners[0] = GameObject.FindObjectOfType<Follow>().gameObject;
        }
        if (target == null) target = GameObject.FindObjectOfType<BallController>().transform;
        GameController gc = GameObject.FindObjectOfType<GameController>();
        gc.OnEnterSwipeArea += StartFollowing;
        gc.OnWin += StopFollowing;
        gc.OnGameOver += StopFollowing;
    }

    private void StartFollowing()
    {
        foreach(GameObject listener in followingListeners)
            ExecuteEvents.Execute<IFollowing>(listener,null,(x,y) => x.ChangeTarget());
        if(followingCoroutine!=null)
            StopCoroutine(followingCoroutine);
        followingCoroutine = StartCoroutine(FollowTarget());
    }

    private void StopFollowing()
    {
        StartCoroutine(WaitAndStop());
    }

    private IEnumerator WaitAndStop()
    {
        yield return new WaitForSeconds(1f);
        if(followingCoroutine!=null)
            StopCoroutine(followingCoroutine);
        followingCoroutine = null;
    }

    private IEnumerator FollowTarget()
    {
        transform.position = new Vector3(target.position.x,target.position.y,target.position.z-3f);
        Vector3 startPosition = new Vector3(target.position.x,target.position.y,target.position.z-1f);
        while(true)
        {
            transform.position = Vector3.Lerp (transform.position, (target.position-startPosition)*0.4f+startPosition, Time.deltaTime * smooth);
            yield return new WaitForEndOfFrame();
        }
    }
}
