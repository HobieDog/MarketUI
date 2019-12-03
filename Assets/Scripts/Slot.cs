using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector]

    public ItemProperty itemProperty;
    public Image img;
    public Button sellBtn;

    void Awake()
    {
        SetSellBtn(false);
    }

    void SetSellBtn(bool type)
    {
         if(sellBtn != null)
        {
            sellBtn.interactable = type;
        }
    }

    public void SetItem(ItemProperty item)
    {
        this.itemProperty = item;

        if(item == null)
        {
            img.enabled = false;
            SetSellBtn(false);
            gameObject.name = "Empty";
        }
        else
        {
            img.enabled = true;
            gameObject.name = itemProperty.itemName;
            img.sprite = itemProperty.sprite;
            SetSellBtn(true);
        }
    }

    public void OnClickSellBtn()
    {
        SetItem(null);
    }
}
