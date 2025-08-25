using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DownCounterView : MonoBehaviour
{
    [SerializeField] private GameObject counterObject;
    void Start()
    {
        StartCountdown counter = GameObject.FindObjectOfType<StartCountdown>();
        counter.OnChangeDelay += ChangeCounterText;
        counter.OnDelayEnd += HideCounterText;
    }

    private void ChangeCounterText(int secondsCount)
    {
        Text counterText = (Text)counterObject.GetComponent<Text>();
        if(secondsCount == 0)
        {
            counterText.text = "ROLL";
        }
        else
        {
            counterText.text = secondsCount.ToString();
        }
    }

    private void HideCounterText()
    {
        counterObject.SetActive(false);
    }

    
}
