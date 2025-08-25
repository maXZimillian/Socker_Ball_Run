using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Text valuableText;
    public Skin[] skinProps = new Skin[0];
    private int valuableCount = 0;
    private ShopItem[] shopItems;
    private SaveGame manager;

    public event Action<int> OnObjectSelected;
    public event Action<Skin[]> OnDataLoaded;

    private void Start()
    {
        PurchasePopup purchasePopup = FindObjectOfType<PurchasePopup>();
        purchasePopup.OnValuableChanged += OnValuableChange;

        manager = new SaveGame();
        SaveData data = manager.LoadGame();
        skinProps = data.skinsProps;
        ChangeValuableCount(data.currentGemsCount);
        shopItems = FindObjectsOfType<ShopItem>();
        foreach(ShopItem item in shopItems)
        {
            item.OnSkinChanged += SaveChangedObject;
            item.OnSkinSelected += ChangeSelectedObject;
        }
        OnDataLoaded?.Invoke(skinProps);
        Debug.Log("Invoke drawing panels");
    }

    private void ChangeValuableCount(int newCount)
    {
        valuableCount = newCount;
        valuableText.text = valuableCount.ToString();
    }

    private void ChangeSelectedObject(Skin changedObj)
    {
        SaveChangedObject(changedObj);
        Debug.Log("changed object with ID = " + changedObj.id);
        OnObjectSelected?.Invoke(changedObj.id);
    }

    private void SaveChangedObject(Skin changedObj)
    {
        ChangeObject(changedObj);
        SaveData prevSave = manager.LoadGame();
        manager.Save(prevSave.currentLevel, prevSave.currentGemsCount,skinProps);
    }

    private void ChangeObject(Skin changedObj)
    {
        bool changed = false;
        for(int i = 0; i < skinProps.Length; i++)
        {
            if (skinProps[i].id == changedObj.id)
            {
                skinProps[i] = changedObj;
                changed = true;
            }
        }
        if (!changed)
        {
            Array.Resize(ref skinProps, skinProps.Length + 1);
            skinProps[skinProps.Length-1] = changedObj;
        }
    }

    private void OnValuableChange()
    {
        ChangeValuableCount(new SaveGame().LoadGame().currentGemsCount);
    }    



}
