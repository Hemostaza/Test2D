using Godot;
using System;


public partial class InventoryComponent : Node
{
    [Export]
    ItemData[] itemsData = new ItemData[3];

    public ItemData GetItemDataFromSlot(int slot){
        return itemsData[slot];
    }

    public ItemData[] GetItemsData(){
        return itemsData;
    }

    public bool TryInsertItem(ItemData itemData){
        if(itemData == null){
            return false;
        }
        int insertToSlot = GetEmptySlot();
        if(insertToSlot<0){
            return false;
        }
        itemsData[insertToSlot] = itemData;
        return true;
    }

    public bool isSlotEmpty(int slot){
        if(itemsData[slot]==null){
            return true;
        }
        return false;
    }

    public int GetEmptySlot(){
        for (int i = 0; i < itemsData.Length; i++)
        {
            if(isSlotEmpty(i)) return i;
        }
        return -1;
    }
}
