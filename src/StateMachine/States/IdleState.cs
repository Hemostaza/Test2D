using Godot;
using System;
using System.Linq;

public partial class IdleState : State
{
    public override void Enter(){
        animation = "idle";
        base.Enter();
    }
    public override void PhysicsUpdate(double delta)
    {
        
        base.PhysicsUpdate(delta);
        if(parent.Velocity!=Vector2.Zero){
            parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*5);
        }
        
        if(action==Actions.WALK){
            EmitSignal(SignalName.transitioned,this,"Walk");
        }

        if(action==Actions.ATTACK){
            EmitSignal(SignalName.transitioned,this,"Attack");
        }

        if(parent.IsOnFloor() && action==Actions.JUMP){
            EmitSignal(SignalName.transitioned,this,"Jump");
        }
    }
}
