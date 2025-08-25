using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGoalEffect : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private bool hideAfterEffect;
    [SerializeField] private Renderer[] needToHideObjects;
    void Start()
    {
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.OnWin += PlayEffect;
    }

    private void PlayEffect()
    {
        if (effect)
            Instantiate(effect, transform.position, Quaternion.identity);
        if (hideAfterEffect)
        {
            transform.parent.GetComponent<Renderer>().enabled = false;
            foreach(Renderer renderer in needToHideObjects)
            {
                renderer.enabled = false;
            }
        }
    }
}
