using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] int levelsCount = 5;
    [SerializeField] Text prevLevel;
    [SerializeField] Text currLevel;
    private int maxLevelToOpen = 1;
    private int levelToOpen = 1;

    private void Start()
    {
        //new SaveGame().Reset();
        maxLevelToOpen = new SaveGame().LoadGame().currentLevel;
        prevLevel.text = (maxLevelToOpen-1).ToString();
        if(maxLevelToOpen>levelsCount)maxLevelToOpen=levelsCount;
        currLevel.text = maxLevelToOpen.ToString();
        levelToOpen = maxLevelToOpen;
    }

    public void BackToPrevLevel(){
        levelToOpen = levelToOpen-1<1?1:levelToOpen-1;
        prevLevel.text = (levelToOpen-1).ToString();
        currLevel.text = levelToOpen.ToString();
    }

    public void GoToNextLevel(){
        if(levelToOpen<maxLevelToOpen){
            levelToOpen = levelToOpen+1;
            prevLevel.text = (levelToOpen-1).ToString();
            currLevel.text = levelToOpen.ToString();
        }
    }

    public void ShowShopPanel(){
        shopPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void PlayButtonClick(){
        OpenLevel(levelToOpen);
    }

    public void ShowMainPanel(){
        mainPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void OpenLevel(int number){
        SceneManager.LoadScene(number+1);
    }

}
