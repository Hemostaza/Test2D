using Godot;
using System;

public partial class IdleState : State
{
    public override void Enter(){
        animation = "idle";
        base.Enter();
    }
    public override void PhysicsUpdate(double delta)
    {
        if(parent.Velocity!=Vector2.Zero){
            parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*5);
        }

        if(moveCompontent.GetMovementDirection()!=0){
            GD.Print("chu:");
            EmitSignal(SignalName.transitioned,this,"Walk");
        }

        if(moveCompontent.GetAttackInput(true)){
            EmitSignal(SignalName.transitioned,this,"Attack");
        }

        if(!parent.IsOnFloor()){
            EmitSignal(SignalName.transitioned,this,"Fall");
        }

        if(parent.IsOnFloor() && moveCompontent.GetJumpInput(true)){
            EmitSignal(SignalName.transitioned,this,"Jump");
        }
    }
}
