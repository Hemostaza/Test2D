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
        
        bool isFront = animationPlayer.CurrentAnimation.Contains("hitFront");

        if(!isFront){
            animation = "fall2Continue";
        }else{
            animation = "hitFrontContinue";
        }
        UpdateAnimation(animation);
        base.Enter();
    }
    public override void PhysicsUpdate(double delta){

        //parent.Velocity += new Vector2(parent.hitDirection.X*20,-250);
        if(parent.Velocity.Y<=1000){
            parent.Velocity += new Vector2(0,(float)gravity);
        }
        if(parent.IsOnFloor()){
            if(animation.Equals("hitFrontContinue")){
                animation = "hitFrontFloor";
            }else if(animation.Equals("fall2Continue")) animation = "hitFloor";

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
