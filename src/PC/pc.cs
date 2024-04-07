using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class pc : Entity
{
    [Export]
    public InventoryComponent inventoryComponent;

    public List<Item> focusedItem = new List<Item>();

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Falling();
        //inventoryComponent.GetKeySlot();

        if(Input.IsActionJustPressed("interact") && focusedItem.Any()){
                if(focusedItem[0].GetItemData().itemFlags.HasFlag(ItemFlag.isPickable)){
                    GD.Print("chuj");
                    stateMachine.ChangeState("PickUp");
                    //(currentState as PickUpState).SetFocusedItem(focusedItem[0]);
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

    public override ItemData GetActiveItem()
    {
        return inventoryComponent.GetActiveItem();
    }
}
