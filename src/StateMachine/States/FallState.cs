using Godot;
using System;

public partial class FallState : State
{
    [Export]
    double gravity = 20;

    double xSpeed = 0;
    bool isContinue = false;
    double fallingTime=0;
    double lyingTime = 0.2;
    public override void Enter(){
        animation = "fall";
        xSpeed = parent.Velocity.X*2;
        isContinue = false;
        fallingTime = 0;
        base.Enter();
    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta){
        fallingTime+=delta;
        if(fallingTime>0){
            if(!isContinue && fallingTime>parent.safeTimeInAir){
                UpdateAnimation("fall2Continue");
                AnimationQueue("fallContinue");
                lyingTime=0.5;
                isContinue = true;
            }
            float moveSpeed = moveCompontent.WantMove() * 25;
            if(fallingTime<1 || fallingTime>1.5){
                UpdateAnimation(animation);
            }
            parent.Velocity = new Vector2(moveSpeed+(float)xSpeed,parent.Velocity.Y);
            if(parent.Velocity.Y<=1000){
                parent.Velocity += new Vector2(0,(float)gravity);
            }
        }
        if(parent.IsOnFloor()){
            Land(delta);
        }
        if(fallingTime<0 && !parent.IsOnFloor()){
            Enter();
        }
    }

    public void Land(double delta){
        if(parent.Velocity!=Vector2.Zero){
            parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*15);
        }
        if(fallingTime>1){
            ChangeAnimation("hitFloor");
            AnimationQueue("getUp");
        }else if(fallingTime>0){
            ChangeAnimation("getUp");
            lyingTime=0.2;
            //EmitSignal(SignalName.transitioned,this,"Idle");
        }
        lyingTime-=delta;
        if(lyingTime<=0){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
        fallingTime=-1;
    }
    public override void Exit(){
        base.Exit();
    }

    void ChangeAnimation(String animation){
        this.animation = animation;
        UpdateAnimation(animation);
    }
}
