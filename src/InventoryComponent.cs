using Godot;
using System;

//może być resource
public partial class InventoryComponent : Node
{
    [Export]
    InventoryData inventoryData;
    [Export]
    Sprite2D ItemNode;
    
    ItemData activeItem;
    int activeSlot = 0;
    
    [Signal]
    public delegate void updateActiveSlotEventHandler(int slot, int previousSlot);
    [Signal]
    public delegate void updateInactiveSlotEventHandler(int slot);
    [Signal]
    public delegate void updateSlotEventHandler(int slot, Item item);

    public override void _PhysicsProcess(double delta)
    {
        GetKeySlot();
    }

    public void GetKeySlot(){
        if(Input.IsActionJustPressed("slot1")){
            UpdateActiveSlot(1);
        }
        if(Input.IsActionJustPressed("slot2")){
            UpdateActiveSlot(2);
        }
        if(Input.IsActionJustPressed("slot3")){
            UpdateActiveSlot(3);
        }
    }
    public void UpdateActiveSlot(int slot){
        if(activeSlot==slot){
            SetSlotInactive(slot);
            return;
        }
        ItemData newActiveItem = inventoryData.GetItemDataFromSlot(slot);
        if(newActiveItem!=null){
            activeItem = newActiveItem;
            //Jest item aktywny
            int previousSlot = activeSlot;
            activeSlot = slot;
            GD.Print("Emit signal SignalName.updateActiveSlot "+activeSlot+ " " +previousSlot);
            EmitSignal(SignalName.updateActiveSlot, activeSlot, previousSlot);
            ShowItemInHand(activeItem); //wyciagniecie itemu 
        }
        
        //zmiany zachodzace w PC za item ktory jest wybrany
    }

    public ItemData GetActiveItem(){
        if(activeSlot>0)
            return inventoryData.GetItemDataFromSlot(activeSlot);
        else
            return null;
    }

    void ShowItemInHand(ItemData itemData){
        //Jeżeli item jest bronią to wyciaga go jako Item a nie ItemData? Coś w tym stylu?
        ItemNode.Visible = true;
        ItemNode.Texture = itemData.texture;
    }
    void HideItemInHand(){
        ItemNode.Visible = false;
    }

    void SetSlotInactive(int slot){
        activeSlot = 0;
        HideItemInHand();
        activeItem = null;
        GD.Print("Emit signal SignalName.updateInactiveSlot "+slot);
        EmitSignal(SignalName.updateInactiveSlot, slot);
        //ustawienie slotu nieaktywnego.
        //emit signal inactiveslot - 
    }

    public void UpdateInventory(Item item){
        //if(inventoryData.TryInsertItem(item)){
        int slotInserted = inventoryData.TryInsertItem(item);
        GD.Print("Emit signal SignalName.updateSlot "+slotInserted +" "+item);
        EmitSignal(SignalName.updateSlot,slotInserted, item);
       // }
    }
}
