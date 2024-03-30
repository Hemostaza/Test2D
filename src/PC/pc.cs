using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class pc : Entity
{

    public List<Item> focusedItem = new List<Item>();
    [Export]
    Area2D interactionArea;
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Falling();
        if(Input.IsActionJustPressed("interact") && focusedItem.Any()){
            //if(focusedItem.HasMethod("PickUp")){
                if(focusedItem[0].itemFlags.HasFlag(ItemFlag.isPickable)){
                    stateMachine.ChangeState("PickUp");
                }
                
            //}
        }

    }


    void OnInteractAreaEntered(Area2D area2D){
        Item ins = area2D.GetParent() as Item;
        GD.Print("entered "+ins.Name);
        if(ins!=null){
            focusedItem.Insert(0,ins);
        }
        GD.Print("focused item = "+focusedItem.ToString());
    }

    void OnInteractAreaExited(Area2D area2D){
        Item ins = area2D.GetParent() as Item;
        GD.Print("exited "+ins.Name);
        if(ins!=null){
            focusedItem.Remove(ins);
        }
        
            GD.Print("focused item = "+focusedItem.ToString());
    }
}
