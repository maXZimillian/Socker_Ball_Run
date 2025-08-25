using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveUISceneController : MonoBehaviour
{
    [SerializeField] private SideMoveController sideMoveController;
    [SerializeField] private GateMove gateMove;
    [SerializeField] private LineRenderer drawingLine;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }
 
    private IEnumerator LoadSceneAsync()
    {
        yield return SceneManager.LoadSceneAsync((int)SceneIndex.LevelUI, LoadSceneMode.Additive);
        UserUIComponentsProducer UIComponentsProducer = FindObjectOfType<UserUIComponentsProducer>();
        sideMoveController.touchHandler = UIComponentsProducer.touchPanel;
        gateMove.touchHandler = UIComponentsProducer.touchPanel;
        UIComponentsProducer.lineDrawer.lineRenderer = drawingLine;
    }
}
