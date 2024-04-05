using Godot;
using System;
using System.Data;

public partial class PickUpState : State
{
    Item focusedItem;
    pc pc;
    //InventoryComponent inventoryComponent;
    public override void InitState()
    {
        base.InitState();
        pc = parent as pc;
        if(pc==null){
            throw new NullReferenceException();
        }
       // inventoryComponent = parent.GetInventoryComponent();
    }
    public override void Enter(){
        GD.Print("pikap stejt");
        //focusedItem = pc.focusedItem[0];
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

    public void SetFocusedItem(Item focusedItem){
        this.focusedItem = focusedItem;
    }
}
