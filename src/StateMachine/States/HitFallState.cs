using Godot;
using System;

public partial class HitFallState : State
{
    [Export]
    double hitFallTimer = 1;
    double onFloor = 0;
    double gravity = 20;
    public override void Enter()
    {   
        onFloor = hitFallTimer;
        if(parent.hitDirection==Vector2.Right){
            animation = "hitFrontContinue";
        }else animation = "fall2Continue";
        GD.Print("hitfall");
        base.Enter();
    }
    public override void PhysicsUpdate(double delta){

        //parent.Velocity += new Vector2(parent.hitDirection.X*20,-250);
        if(parent.Velocity.Y<=1000){
            parent.Velocity += new Vector2(0,(float)gravity);
        }
        if(parent.IsOnFloor()){
            if(parent.hitDirection==Vector2.Right){
                animation = "hitFrontFloor";
            }else animation = "hitFloor";

            if(parent.Velocity!=Vector2.Zero){
                parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*5);
            }
            UpdateAnimation(animation);
            onFloor-=delta;
            if(onFloor<=0){
                EmitSignal(SignalName.transitioned,this,"Idle");
            }
        }
    }
}
