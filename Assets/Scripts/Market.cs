using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public ItemBuffer itemBuffer;
    public Transform slotRoot;

    private List<Slot> slots;

    public System.Action<ItemProperty> onClickSlot;

    void Start()
    {
        slots = new List<Slot>();
        int slotCnt = slotRoot.childCount;

        for(int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if(i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }
            else
            {
                slot.GetComponent<Button>().interactable = false;
            }

            slots.Add(slot);
        }
    }

    void Update()
    {
        
    }

    public void OnClickSlot(Slot slot)
    {
        if(onClickSlot != null)
        {
            onClickSlot(slot.itemProperty);
        }
    }
}
