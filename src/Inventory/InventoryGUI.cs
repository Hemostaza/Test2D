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
        player.inventoryComponent.updateActiveSlot += UpdateActiveSlot;
        player.inventoryComponent.updateInactiveSlot += UpdateInactiveSlot;
        player.inventoryComponent.updateSlot += UpdateSlot;

    }

    void UpdateSlot(int slot, Item item){
        if(slot!=-1){
            slots[slot].UpdateSlot(item);
        }
    }

    void UpdateActiveSlot(int slot, int previousSlot){
        
        if(previousSlot>0){
            slots[previousSlot-1].SetInactiveSlot();
        }
        slots[slot-1].SetActiveSlot();
    }
    void UpdateInactiveSlot(int slot){
        slots[slot-1].SetInactiveSlot();
    }
    void InactiveSlots(){
        foreach (SlotData slot in slots)
        {
            slot.SetInactiveSlot();
        }
    }
}
