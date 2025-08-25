using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Follow : MonoBehaviour, IFollowing
{
    [SerializeField] private Transform[] targets;
    [SerializeField] private float smooth= 5.0f;
    [SerializeField] private float smoothCenter= 3.0f;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -2);

    private Transform target;
    private bool move = true;
    private int targetNumber = 0;
    private Coroutine moveCoroutine = null;

    private void Start()
    {
        if(targets.Length==0)
        {
            targets = new Transform[3];
            targets[0] = GameObject.FindObjectOfType<CameraPreMover>().transform;
            targets[1] = GameObject.FindObjectOfType<BallController>().transform;
            targets[2] = GameObject.FindObjectOfType<GateCameraMover>().transform;
        }
        target = targets[0];
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.OnGameOver +=StopFollowing;
    }

    void Update ()
    {
        if(move)
        transform.position = Vector3.Lerp (transform.position, target.position + offset, Time.deltaTime * smooth);
    }

    public void ChangeTarget(){
        targetNumber++;
        target = targets[targetNumber]; 
    }

    public void StopFollowing(){
        Destroy(this);
    }

    public void StopOnCenter(){
        move = false;
        if(moveCoroutine!=null)
            StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToCenter());
    }

    private IEnumerator MoveToCenter()
    {
        float startPosition = transform.position.x;
        Vector3 destPosition = new Vector3(0f,transform.position.y,transform.position.z);
        if(startPosition>0f)
        {
            while(transform.position.x>0.01f)
            {
                transform.position = Vector3.Lerp (transform.position, destPosition, Time.unscaledDeltaTime * smoothCenter);
                yield return new WaitForEndOfFrame();
            }
        }else
        if(startPosition<0f)
        {
            while(transform.position.x<-0.01f)
            {
                transform.position = Vector3.Lerp (transform.position, destPosition, Time.unscaledDeltaTime * smoothCenter);
                yield return new WaitForEndOfFrame();
            }
        }
        yield return null;
    }

}

public interface IFollowing: IEventSystemHandler
{
    void ChangeTarget();
    void StopFollowing();
}
