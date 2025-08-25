using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class BallController : MonoBehaviour, IBallModel
{
    public Rigidbody ballBody{get;private set;}
    [SerializeField] private float startSpeed = 7f;
    [SerializeField] private bool autoSlowDownSpeed = true;
    [SerializeField] private float customSlowDownBySecond = 0.7f;
    [SerializeField] private float addingSpeed = 7f;
    [SerializeField] private float jumpOnHitForce = 10f;
    [SerializeField] private float kickUpForce = 10f;
    [SerializeField] private float obstacleStopForce = 1f;
    [SerializeField] private float maxAngularVelocity = 20f;
    private float speed;
    private Coroutine slowDownCoroutine;
    private Coroutine move;

    public event Action OnStop;

    private void Start()
    {
        speed = startSpeed;
        ballBody = GetComponent<Rigidbody>();
        ballBody.maxAngularVelocity = maxAngularVelocity;
    }

    public void StartMove()
    {
        move = move == null ? StartCoroutine(Move()) : move;
        slowDownCoroutine = slowDownCoroutine == null ? StartCoroutine(ballContinuousSlowDown()) : slowDownCoroutine;
        ballJump(jumpOnHitForce);
    }

    public void StopAcceleration(){
        if(move!=null)StopCoroutine(move);
        move=null;
        if(slowDownCoroutine!=null)
        {
            StopCoroutine(slowDownCoroutine);
        }
    }
    
    public void OnCheckpointEnter()
    {
        speed+=addingSpeed;
        ballJump(jumpOnHitForce);
    }
    
    public void OnObstacleCollide()
    {
        speed-=obstacleStopForce;
        ballJump(jumpOnHitForce);     
    }

    public void OnKickUp()
    {
        ballJump(kickUpForce);
    }

    private void ballJump(float jumpForce){
        Vector3 movement = new Vector3(0.0f, 1f, 0f);
        ballBody.AddForce((movement * jumpForce),ForceMode.Impulse);
    }

    IEnumerator Move()
    {
        while (true)
        {
            Vector3 movement = new Vector3(ballBody.velocity.x, ballBody.velocity.y, 1f * speed);
            ballBody.velocity = movement;
            float c = 2f * Mathf.PI * 0.11f;
            float cProcentOnSec = speed / c;
            float angVelocity = 2f * Mathf.PI * cProcentOnSec;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ballContinuousSlowDown(){
        while(speed>0.0f){
            if (autoSlowDownSpeed)
            {
                speed -= startSpeed * Time.fixedDeltaTime / 10f;
            }else
            {
                speed -= customSlowDownBySecond * Time.fixedDeltaTime;
            }
            yield return new WaitForFixedUpdate();
        }
        StopCoroutine(move);
        move=null;
        OnStop.Invoke();
    }
}

public interface IBallModel: IEventSystemHandler{
    void StopAcceleration();
    void OnKickUp();
    void OnObstacleCollide();
    void OnCheckpointEnter();
    void StartMove();
}

