using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class pc : Entity
{
    [Export]
    InventoryComponent inventoryComponent;

    [Export]
    ItemData chuj;

    public List<Item> focusedItem = new List<Item>();
    //public Dictionary<Item,ItemData> focusedItem = new Dictionary<Item, ItemData>();

    // public InventoryData GetInventoryData(){
    //     return inventoryData;
    // }

    public override void _Ready()
    {
        base._Ready();
        //GD.Print(inventoryComponent.GetItemDataFromSlot(0).GetType());
        //GD.Print(inventoryComponent.TryInsertItem(chuj));
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Falling();
        if(Input.IsActionJustPressed("interact") && focusedItem.Any()){
                if(focusedItem[0].GetItemData().itemFlags.HasFlag(ItemFlag.isPickable)){
                    GD.Print("chuj");
                    stateMachine.ChangeState("PickUp");
                    (currentState as PickUpState).SetFocusedItem(focusedItem[0]);
            }
        }
    }


    void OnInteractAreaEntered(Area2D area2D){
        Item ins = area2D.GetParent() as Item;
        GD.Print("entered "+ins.Name);
        if(ins!=null){
            focusedItem.Add(ins);
        }
    }

    void OnInteractAreaExited(Area2D area2D){
        Item ins = area2D.GetParent() as Item;
        GD.Print("exited "+ins.Name);
        if(ins!=null){
            focusedItem.Remove(ins);
        }
    }
}
