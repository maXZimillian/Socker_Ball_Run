using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] GameObject pointsText;
    [SerializeField] GameObject addingPointsText;
    [SerializeField] float scaleSpeedMultiplier = 0.1f;
    private int points = 0;
    private int addingPoints = 0;
    private int tempAddingPoints = 0;
    private bool isAnimating = false;

    private void Start() {
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.OnCollect += CollectPoints;
    }

    private void AddTempPoints(int count){
        addingPoints+=count;
        tempAddingPoints+=count;
        Text countText = (Text)addingPointsText.GetComponent<Text>();      
        countText.text = "+"+(tempAddingPoints).ToString();
    }

    private void AddPoints(int count){
        points+=count;
        Text countText = (Text)pointsText.GetComponent<Text>();
        countText.text = (points).ToString();
    }

    public void CollectPoints(int count){
        AddTempPoints(count);
        if(!isAnimating)
            StartCoroutine(AnimatePoints());
    }

    IEnumerator AnimatePoints(){
        isAnimating = true;
        while(addingPoints>0){
            addingPoints--;
            AddPoints(1);
            bool isAnimated = false;
            while(!(pointsText.transform.localScale.x<=1.0f&&isAnimated)){
                pointsText.transform.localScale =isAnimated?
                new Vector3(pointsText.transform.localScale.x-scaleSpeedMultiplier,pointsText.transform.localScale.y-scaleSpeedMultiplier,pointsText.transform.localScale.z-scaleSpeedMultiplier):
                new Vector3(pointsText.transform.localScale.x+scaleSpeedMultiplier,pointsText.transform.localScale.y+scaleSpeedMultiplier,pointsText.transform.localScale.z+0.05f);
                if(pointsText.transform.localScale.x>=1.2f){
                    isAnimated = true;
                }
                yield return new WaitForFixedUpdate();
            }
        }
        Text countText = (Text)addingPointsText.GetComponent<Text>();
        countText.text = "";
        tempAddingPoints = 0;
        isAnimating = false;
    }


}
