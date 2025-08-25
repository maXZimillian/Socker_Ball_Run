using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PurchasePopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private Text costText;
    [SerializeField] private Button agreeButton;
    [SerializeField] private Button cancelButton;

    private int itemId = 0;
    private int itemCost = 0;

    public event Action<int> OnPurchaseItem;
    public event Action OnValuableChanged;
    private void Start()
    {
        ShopItem[] shopItems = FindObjectsOfType<ShopItem>();
        foreach(ShopItem item in shopItems)
        {
            item.OnSkinPurchase += ShowPopup;
        }
    }

    private void ShowPopup(int id,int cost)
    {
        itemId = id;
        itemCost = cost;
        costText.text = cost.ToString();
        popup.SetActive(true);
        if(new SaveGame().LoadGame().currentGemsCount < cost)
        {
            agreeButton.interactable = false;
        }
        else
        {
            agreeButton.interactable = true;
        }
    }

    public void Purchase()
    {
        popup.SetActive(false);
        SaveData saveData = new SaveGame().LoadGame();
        new SaveGame().Save(saveData.currentLevel, saveData.currentGemsCount - itemCost);
        OnPurchaseItem?.Invoke(itemId);
        OnValuableChanged?.Invoke();
    }

    public void CancelPurchase()
    {
        popup.SetActive(false);
    }
}
