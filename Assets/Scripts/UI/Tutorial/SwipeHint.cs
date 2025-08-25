using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwipeHint : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition = new Vector3(230f,0f,0f);
    [SerializeField] private Vector3 destPosition = new Vector3(-230,0f,0f);
    [SerializeField] private bool slowTime = true;
    [SerializeField] private float timeScale = 0.3f;
    [SerializeField] private Image hintImage;
    [SerializeField] private float showSpeed = 0.01f;
    private Coroutine showHintCoroutine = null;

    private void Start() {

    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            TouchHandler handler = GameObject.FindObjectOfType<TouchHandler>();
            handler.OnTouchEnd += CloseHint;
            if(showHintCoroutine!=null)
                StopCoroutine(showHintCoroutine);
            showHintCoroutine = StartCoroutine(ShowHint());
        }
    }

    private void CloseHint(){
        if(showHintCoroutine!=null){
            StopCoroutine(showHintCoroutine);
            showHintCoroutine=null;
            Time.timeScale = 1f;
            var tempColor = hintImage.color;
            tempColor.a = 0;
            hintImage.color = tempColor;
        }
    }

    private IEnumerator ShowHint(){ 
        Vector3 step = destPosition-startPosition;
        step/=60f;
        for(int i=0;i<3;i++){
            hintImage.transform.localPosition = startPosition;
            while(slowTime&&Time.timeScale>timeScale||hintImage.color.a<1f){
                    if(slowTime)Time.timeScale = Time.timeScale-showSpeed*Time.unscaledDeltaTime/0.01f<timeScale?timeScale:Time.timeScale-showSpeed*Time.unscaledDeltaTime/0.01f;
                    var tempColor = hintImage.color;
                    tempColor.a += showSpeed*Time.unscaledDeltaTime/0.01f;
                    hintImage.color = tempColor;
                yield return new WaitForEndOfFrame();
            }
            if(hintImage.transform.localPosition.x>destPosition.x)
                while(hintImage.transform.localPosition.x>destPosition.x){
                    hintImage.transform.localPosition +=step*Time.unscaledDeltaTime/0.01f;
                    yield return new WaitForEndOfFrame();
                } 
            else
                while(hintImage.transform.localPosition.x<destPosition.x){
                    hintImage.transform.localPosition +=step*Time.unscaledDeltaTime/0.01f;
                    yield return new WaitForEndOfFrame();
                }  
            while(hintImage.color.a>0f){
                    var tempColor = hintImage.color;
                    tempColor.a -= showSpeed*Time.unscaledDeltaTime/0.01f;
                    hintImage.color = tempColor;
                yield return new WaitForEndOfFrame();
            } 
        }  
        Time.timeScale=1f;
        yield return null;
    }
}
