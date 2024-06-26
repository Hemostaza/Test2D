using Godot;
using System;

public partial class GetHitState : State
{
    [Export]
    double maxTimeInState = 0.5;
    double timeInHitState = 0;
    int currentHit = 0;
    [Export]
    int maxHit = 3;
    
    public override void Enter()
    {
        timeInHitState=0;
        // if(parent.hitDirection==Vector2.Right || parent.hitDirection==Vector2.Zero){
        //     animation = "hitFront";
        // }else animation = "hitBack";
        //base.Enter();
    }

    public override void Update(double delta)
    {
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        timeInHitState += delta;
        if(timeInHitState<=0.2){
            //EmitSignal(SignalName.transitioned,this,nameof(moveCompontent.GetActions()[0]));
        }
        if(timeInHitState>maxTimeInState){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
        
    }

    public void GetHit(double power, Vector2 hitSide){

        Vector2 parentDir = parent.GetFacingDirection();

        if(hitSide+parentDir!=Vector2.Zero){
            animation = "hitBack";
        }else animation = "hitFront";
        UpdateAnimation(animation);

        parent.Velocity = new Vector2(hitSide.X*10,0);
        timeInHitState=0;
        currentHit+=1;
        if(currentHit>=maxHit){
            EmitSignal(SignalName.transitioned,this,"HitFall");
            parent.Velocity = new Vector2(hitSide.X*(float)power,-150);
        }
    }

    public override void Exit()
    {   
        currentHit = 0;
        base.Exit();
    }
}
