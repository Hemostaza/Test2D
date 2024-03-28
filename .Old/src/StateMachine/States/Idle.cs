using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Idle : State
{
    public override void Enter(){
        base.Enter();
        animationPlayer.Play("idle"+side);
        player.Velocity = Vector2.Zero;
    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta)
    {
        if(GetMovementInput()!=Vector2.Zero){
            EmitSignal(SignalName.transitioned,this,"Walk");
        }
        if(Input.IsActionJustPressed("fire")){
            EmitSignal(SignalName.transitioned,this,"Punch");
        }
        if(Input.IsActionJustPressed("jump")){
            EmitSignal(SignalName.transitioned,this,"Jump");
        }
        //EmitSignal(SignalName.transitioned,this,"Walk");
    }
}