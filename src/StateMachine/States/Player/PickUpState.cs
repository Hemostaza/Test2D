using Godot;
using System;
using System.Data;

public partial class PickUpState : State
{
    Item focusedItem;
    InventoryComponent inventoryComponent;
    public override void InitState()
    {
        base.InitState();
        inventoryComponent = (parent as pc).inventoryComponent;
    }
    public override void Enter(){
        GD.Print("pikap stejt");
        
        focusedItem = (parent as pc).focusedItem[0];
        ItemPickUp(focusedItem);
       // inventoryComponent.PutItemInInventory(focusedItem);
    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta){
        EmitSignal(SignalName.transitioned,this,"Idle");
    }
    public override void Exit(){
        base.Exit();
    }

    void ItemPickUp(Item focusedItem){
        inventoryComponent.UpdateInventory(focusedItem); //podniesienie itemu i wsadzenie go w unventoryComponent
        focusedItem.QueueFree();
    }

}
