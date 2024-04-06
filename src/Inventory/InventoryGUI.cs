using Godot;
using System;

public partial class InventoryGUI : Node
{
    [Export]
    pc player;
    [Export]
    SlotData[] slots = new SlotData[3];
    int activeSlot = 0;
    public override void _Ready()
    {
        player.inventoryComponent.updateActiveInventory += UpdateActiveSlot;
        player.inventoryComponent.updateSlot += UpdateSlot;

    }

    void UpdateSlot(int slot, Item item){
        if(slot!=-1){
            slots[slot].UpdateSlot(item);
        }
    }

    void UpdateActiveSlot(int slot){
        if(activeSlot==slot){
            activeSlot= -1;
            InactiveSlots();
            return;
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if(i==slot-1 && activeSlot!=slot){
                slots[i].SetActiveSlot();
                activeSlot = slot;
            }
            else {
                slots[i].SetInactiveSlot();
            }
        }
    }
    void InactiveSlots(){
        foreach (SlotData slot in slots)
        {
            slot.SetInactiveSlot();
        }
    }
}
