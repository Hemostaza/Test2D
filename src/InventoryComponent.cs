using Godot;
using System;

//może być resource
public partial class InventoryComponent : Node
{
    [Export]
    InventoryData inventoryData;
    ItemData activeItem;

    [Signal]
    public delegate void updateActiveInventoryEventHandler(int slot);
    [Signal]
    public delegate void updateSlotEventHandler(int slot, Item item);

    int slot = 0;
    public void GetKeySlot(){
        if(Input.IsActionJustPressed("slot1")){
            UpdateActiveItem(1);
        }
        if(Input.IsActionJustPressed("slot2")){
            UpdateActiveItem(2);
        }
        if(Input.IsActionJustPressed("slot3")){
            UpdateActiveItem(3);
        }
    }
    public void UpdateActiveItem(int slot){
        //GD.Print("slot wybrany "+slot);
        //GD.Print("itemData w wybranym slocie: "+inventoryData.GetItemDataFromSlot(slot));
        EmitSignal(SignalName.updateActiveInventory, slot);
        //zmiany zachodzace w PC za item ktory jest wybrany
    }

    public void UpdateInventory(Item item){
        //if(inventoryData.TryInsertItem(item)){
            EmitSignal(SignalName.updateSlot,inventoryData.TryInsertItem(item), item);
       // }
    }
}
