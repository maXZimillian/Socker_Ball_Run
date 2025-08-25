using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private int skinId = 0;
    [SerializeField] private int skinCost = 0;
    [SerializeField] private bool defaultSkin = false;

    [SerializeField] private Text costText;
    [SerializeField] private GameObject selectIcon;
    [SerializeField] private GameObject costPanel;

    private ShopController controller;
    private Skin[] skinProps;
    private Skin currentSkin;

    public event Action<Skin> OnSkinChanged;
    public event Action<Skin> OnSkinSelected;
    public event Action<int,int> OnSkinPurchase;

    private void Awake()
    {
        controller = GameObject.FindObjectOfType<ShopController>();
        Debug.Log("Object number " + skinId + " found controller");
        controller.OnObjectSelected += DeselectSkin;
        controller.OnDataLoaded += OnDataLoaded;
        PurchasePopup purchasePopup = FindObjectOfType<PurchasePopup>();
        purchasePopup.OnPurchaseItem += OnPurchaseItem;

    }

    private void OnDataLoaded(Skin[] skinData)
    {
        skinProps = skinData;
        CheckSkinProps();
    }

    private void CheckSkinProps()
    {
        currentSkin = FindCurrentSkin();
        if (currentSkin == null)
        {
            currentSkin = new Skin();
            currentSkin.id = skinId;
        }
        DrawSkinProps();
    }

    private Skin FindCurrentSkin()
    {
        for(int i = 0; i < skinProps.Length; i++)
        {
            if (skinProps[i].id == skinId)
                return skinProps[i];
        }
        return null;
    }

    private void DrawSkinProps()
    {
        costText.text = skinCost.ToString();
        if (defaultSkin)
        {
            if (!currentSkin.purchased)
            {
                currentSkin.purchased = true;
                OnSkinChanged?.Invoke(currentSkin);
            }
            if (!currentSkin.selected && GetSelectedId() == -1)
            {
                currentSkin.selected = true;
                OnSkinSelected?.Invoke(currentSkin);
            }
        }

        if (currentSkin.purchased)
            costPanel.SetActive(false);
        else
            costPanel.SetActive(true);
        if (currentSkin.selected)
            selectIcon.SetActive(true);
        else
            selectIcon.SetActive(false);
    }

    private int GetSelectedId()
    {
        skinProps = controller.skinProps;
        foreach(Skin item in skinProps)
        {
            if (item.selected)
            {
                return item.id;
            }
        }
        return -1;
    }

    private void DeselectSkin(int newSelectedSkinId)
    {
        if (currentSkin!=null && currentSkin.selected && newSelectedSkinId!=currentSkin.id)
        {
            currentSkin.selected = false;
            DrawSkinProps();
            OnSkinChanged?.Invoke(currentSkin);
        }
    }

    private void OnPurchaseItem(int itemId)
    {
        if (currentSkin.id == itemId)
        {
            currentSkin.purchased = true;
            currentSkin.selected = true;
            DrawSkinProps();
            OnSkinSelected?.Invoke(currentSkin);
        }
    }

    public void ButtonPressed()
    {
        if (currentSkin.purchased)
        {
            currentSkin.selected = true;
            DrawSkinProps();
            OnSkinSelected?.Invoke(currentSkin);
        }
        else
        {
            OnSkinPurchase?.Invoke(currentSkin.id, skinCost);
        }
    }
}
