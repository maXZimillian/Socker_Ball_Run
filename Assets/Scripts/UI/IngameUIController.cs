using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIController : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject swipeHintPopup;
    [SerializeField] GameObject damagePanel;
    [SerializeField] int winPanelDelay = 3;
    [SerializeField] float popupShowSpeed = 0.1f;
    [SerializeField] GameObject[] pointsCollectListeners;
    private Coroutine swipePopupCoroutine = null;
    private Coroutine damageCoroutine = null;

    void Start()
    {
       GameController gameController = GameObject.FindObjectOfType<GameController>();
       gameController.OnWin += ShowPopupOnWin;
       gameController.OnGameOver += ShowLosePopup; 
       gameController.OnEnterSwipeArea += ShowSwipePopup;
       gameController.OnSwipeExit += CloseSwipePopup;
       gameController.OnEscapePressed += ShowPausePopup;
       gameController.OnObstacleHit += ShowDamageEffect;
    }

    private void ShowPopupOnWin(){
        StartCoroutine(ShowWinPopup());
    }

    private void ShowLosePopup(){
        losePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ShowPausePopup(){
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    private void ShowDamageEffect(){
        if(damageCoroutine!=null)
            StopCoroutine(damageCoroutine);
        damageCoroutine = StartCoroutine(DamageEffect());
    }

    private void ShowSwipePopup(){
        if(swipePopupCoroutine!=null)
            StopCoroutine(swipePopupCoroutine);
        swipePopupCoroutine = StartCoroutine(SwipePopupView());
    }
    private void CloseSwipePopup(){
        if(swipePopupCoroutine!=null)
            StopCoroutine(swipePopupCoroutine);
        swipePopupCoroutine = StartCoroutine(SwipePopupUnview());
    }

    IEnumerator ShowWinPopup(){
        yield return new WaitForSeconds(winPanelDelay);
        winPanel.SetActive(true);
        pauseButton.SetActive(false);
    }
    IEnumerator SwipePopupView(){
        swipeHintPopup.SetActive(true);
        CanvasGroup popupGroup = swipeHintPopup.GetComponent<CanvasGroup>();
        popupGroup.alpha = 0f;
        while(popupGroup.alpha<1f){
            popupGroup.alpha+=popupShowSpeed*Time.unscaledDeltaTime*10f;
            yield return new WaitForEndOfFrame();
        }
        swipePopupCoroutine = null;
    }
    IEnumerator SwipePopupUnview(){
        CanvasGroup popupGroup = swipeHintPopup.GetComponent<CanvasGroup>();
        while(popupGroup.alpha>0f){
            popupGroup.alpha-=popupShowSpeed*Time.unscaledDeltaTime*10f;
            yield return new WaitForEndOfFrame();
        }
        swipeHintPopup.SetActive(false);
        swipePopupCoroutine = null;
    }
    IEnumerator DamageEffect(){
        damagePanel.SetActive(true);
        CanvasGroup popupGroup = damagePanel.GetComponent<CanvasGroup>();
        popupGroup.alpha = 0f;
        while(popupGroup.alpha<1f){
            popupGroup.alpha+=popupShowSpeed;
            yield return new WaitForFixedUpdate();
        }
        while(popupGroup.alpha>0f){
            popupGroup.alpha-=popupShowSpeed;
            yield return new WaitForFixedUpdate();
        }
        damageCoroutine = null;
    }
}
