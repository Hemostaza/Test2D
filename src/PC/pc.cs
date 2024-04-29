using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class pc : Entity
{
    [Export]
    public InventoryComponent inventoryComponent;
    [Export]
    InputComponent inputComponent;

    public List<Item> focusedItem = new List<Item>();

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        //inputComponent.GetInput();
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

//Jak by zrobić że obraca sie zawsze w strone kursora to SetFacingDirection - mousePos;
    public override Vector2 GetFacingDirection()
    {
        return inputComponent.direction;
    }

    public override void SetFacingDirection(Vector2 direction)
    {
        inputComponent.direction = direction;
    }

    public override void SetAction(Actions action){
        this.action = action;
    }
    public override Actions GetAction(){
        return inputComponent.GetInput();
    }

    public override float WantMove(){
        return inputComponent.WantMove();
    }
}
