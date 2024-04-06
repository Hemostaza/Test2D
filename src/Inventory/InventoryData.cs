using Godot;
using System;

[GlobalClass]
public partial class InventoryData : Resource
{
    [Export]
    ItemData[] itemsData = new ItemData[3];
    // int activeSlot;
    public ItemData GetItemDataFromSlot(int slot){
        return itemsData[slot-1];
    }

    public ItemData[] GetItemsData(){
        return itemsData;
    }

    // public ItemData GetActiveItem(){
    //     return itemsData[GetActiveSlot()];
    // }

    // public void SetActiveSlot(int slot){
    //     activeSlot = slot;
    // }

    // public int GetActiveSlot(){
    //     return activeSlot;
    // }

    public int TryInsertItem(ItemData itemData){
        
        if(itemData == null){
            return -1;
        }
        int insertToSlot = GetEmptySlot();
        if(insertToSlot<0){
            return -1;
        }
        itemsData[insertToSlot] = itemData;
        GD.Print("Item inserted");
        return insertToSlot;
    }

    public int TryInsertItem(Item item){
        return TryInsertItem(item.GetItemData());
    }

    public ItemData RemoveItemFromSlot(int slot){
        if(isSlotEmpty(slot)){
            return null;
        }
        ItemData item = itemsData[slot];
        itemsData[slot] = null;
        return item;
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
