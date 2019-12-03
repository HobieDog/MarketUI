using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform slotRoot;
    public Market market;

    private List<Slot> slots;
    
    void Start()
    {
        slots = new List<Slot>();

        int slotCnt = slotRoot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }

        market.onClickSlot += BuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        var emptySlot = slots.Find(i =>
        {
            return i.itemProperty == null || i.itemProperty.itemName == string.Empty;
        });

        if(emptySlot != null)
        {
            emptySlot.SetItem(item);
        }
    }
}
