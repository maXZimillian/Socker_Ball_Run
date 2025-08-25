using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    [SerializeField] private float showSpeed = 0.01f;
    [SerializeField] private float closeSpeed = 0.005f;    
    private CanvasGroup hintPanel;
    private Coroutine showHintCoroutine = null;
    public delegate void EnterTrigger();
    public event EnterTrigger OnHintEnter;

    private void Start() {
        hintPanel = GetComponent<CanvasGroup>();
        hintPanel.alpha = 0f;
    }
    private void OnTriggerEnter(Collider other) {
        InteractButton closeButton = GameObject.FindObjectOfType<InteractButton>();
        closeButton.OnButtonPressed += CloseHintInvoke;
        if(other.CompareTag("Player"))
        {
            if(showHintCoroutine!=null)
                StopCoroutine(showHintCoroutine);
            showHintCoroutine = StartCoroutine(ShowHint());
        }
    }

    private void CloseHintInvoke(){
        if(showHintCoroutine!=null)
            StopCoroutine(showHintCoroutine);
        showHintCoroutine = StartCoroutine(CloseHint());

    }

    private IEnumerator ShowHint(){ 
        while(Time.timeScale>0f||hintPanel.alpha<1f){
            Time.timeScale = Time.timeScale-showSpeed*Time.unscaledDeltaTime/0.01f<0f?0f:Time.timeScale-showSpeed*Time.unscaledDeltaTime/0.01f;
            hintPanel.alpha = hintPanel.alpha+showSpeed*Time.unscaledDeltaTime/0.01f;
            yield return new WaitForEndOfFrame();
        }
        if(OnHintEnter!=null)OnHintEnter.Invoke();
    }
    private IEnumerator CloseHint(){
        while(Time.timeScale<1f||hintPanel.alpha>0f){
            Time.timeScale = Time.timeScale+closeSpeed*Time.unscaledDeltaTime/0.01f>1f?1f:Time.timeScale+closeSpeed*Time.unscaledDeltaTime/0.01f;
            hintPanel.alpha = hintPanel.alpha-closeSpeed*Time.unscaledDeltaTime/0.01f;
            yield return new WaitForEndOfFrame();
        }
    }
}
