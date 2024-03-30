using Godot;
using System;

public partial class PickUpState : State
{
    Item focusedItem;
    pc pc;
    public override void Enter(){
        GD.Print("CHUJ");
        if(parent.IsInGroup("Player")){
            pc = parent as pc;
            focusedItem = pc.focusedItem[0];
            GD.Print(focusedItem.Name);
        }
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
}
