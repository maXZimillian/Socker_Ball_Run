using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPopupController : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private bool stopTimeOnShow;
    [SerializeField] private GameObject externShowButton = null;
    [SerializeField] private GameObject nextLevelButton;
    private float prevousTimeScale=0f;
    private void OnEnable() {
        if(stopTimeOnShow){
            prevousTimeScale=Time.timeScale;
            Time.timeScale = 0f;
        }
        if(SceneManager.GetActiveScene().buildIndex+1==SceneManager.sceneCountInBuildSettings&&nextLevelButton!=null)
            nextLevelButton.SetActive(false);
    }
    public void HidePopup(){
        if(stopTimeOnShow)
            Time.timeScale = prevousTimeScale;
        popup.SetActive(false);
        if(externShowButton!=null)externShowButton.SetActive(true);
    }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ReloadScene(){
        if(stopTimeOnShow)
            Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu(){
        if(stopTimeOnShow)
            Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
