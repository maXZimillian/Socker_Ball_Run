using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{   
    [SerializeField] private float swipeAreaTimeScale = 0.1f;
    public int moneyCount {get;private set;} = 0;
    private GameStates gameState = GameStates.game;
    public event Action OnEnterSwipeArea;
    public event Action OnSwipeExit;
    public event Action OnWin;
    public event Action OnGameOver;
    public event Action OnHintEnter;
    public event Action OnEscapePressed;
    public event Action OnObstacleHit;
    public event Action OnBallCenterMove;
    public event Action<int> OnCollect;

    private void Start() 
    {
        BallController b = GameObject.FindObjectOfType<BallController>();
        b.OnStop += GameOver;

        GateMove d = GameObject.FindObjectOfType<GateMove>();
        d.OnSwiped += OnFinalSwipe;

        GoalGateTrigger[] g = GameObject.FindObjectsOfType<GoalGateTrigger>();
        foreach(GoalGateTrigger trigger in g)
        {
            trigger.OnGateEnter += Gate_OnEnterSwipeArea;
            trigger.OnGateExit += Gate_OnExitSwipeArea;
        }

        WinTrigger[] w = GameObject.FindObjectsOfType<WinTrigger>();
        foreach(WinTrigger trigger in w)
            trigger.OnWinEnter += WinGame;

        GameOverTrigger[] t = GameObject.FindObjectsOfType<GameOverTrigger>();
        foreach(GameOverTrigger trigger in t)
            trigger.OnEnter += GameOver;

        Collectible[] c = GameObject.FindObjectsOfType<Collectible>();
        foreach(Collectible item in c)
            item.OnCollect += CollectMoney;
        
        HintController[] h = GameObject.FindObjectsOfType<HintController>();
        foreach(HintController item in h)
            item.OnHintEnter += OnHint;

        Obstacle[] o = GameObject.FindObjectsOfType<Obstacle>();
        foreach(Obstacle item in o)
            item.OnObstacleHit += OnObstacleCollide;

        CenterMoveTrigger[] e = GameObject.FindObjectsOfType<CenterMoveTrigger>();
        foreach(CenterMoveTrigger item in e)
            item.OnEnter += Ball_OnMoveCenter;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)&&gameState==GameStates.game&&OnEscapePressed!=null)
        {
            OnEscapePressed.Invoke();
        }
    }

    private void OnHint()
    {
        if(OnHintEnter!=null)OnHintEnter.Invoke();
    }

    private void OnObstacleCollide()
    {
        Handheld.Vibrate();
        OnObstacleHit?.Invoke();
    }

    private void GameOver()
    {
        if(gameState==GameStates.game){
            OnGameOver?.Invoke();
            gameState = GameStates.gameOver;
        }
    }

    private void Gate_OnEnterSwipeArea()
    {
        GameObject.FindObjectOfType<BallController>().gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        Time.timeScale = swipeAreaTimeScale;
        if(OnEnterSwipeArea!=null)OnEnterSwipeArea.Invoke();
    }
    private void Gate_OnExitSwipeArea()
    {
        StartCoroutine(LoseOnEndDelay());
        if(OnSwipeExit!=null)OnSwipeExit.Invoke();
    }

    private void Ball_OnMoveCenter()
    {
        OnBallCenterMove?.Invoke();
    }

    private void OnFinalSwipe(){
        Time.timeScale = 1.0f;
    }

    private void WinGame(Vector2 winEntryPosition)
    {
        if (gameState==GameStates.game){
            gameState = GameStates.gameOver;
            float pointsMultiplier = Mathf.Abs(winEntryPosition.x)+winEntryPosition.y;
            pointsMultiplier = pointsMultiplier<1f?1f:pointsMultiplier;
            if(Mathf.Abs(winEntryPosition.x)>=2.8f&&winEntryPosition.y>=2.5f)
            {
                pointsMultiplier*=2;
            }
            int moneyToCollect = (int)(GameObject.FindObjectOfType<BallController>().ballBody.velocity.z*pointsMultiplier);
            CollectMoney(moneyToCollect);
            if(OnWin!=null)OnWin.Invoke();
            new SaveGame().Save(SceneManager.GetActiveScene().buildIndex, new SaveGame().LoadGame().currentGemsCount+moneyCount);
        }
    }


    private void CollectMoney(int addingCount)
    {
        moneyCount+=addingCount;
        if(OnCollect!=null)OnCollect.Invoke(addingCount);
    }

    private IEnumerator LoseOnEndDelay(){
        yield return new WaitForSeconds(4f);
        GameOver();
    }
}

public enum GameStates{
    game,
    gameOver
}