using Godot;
using System;

public partial class GetHitState : State
{
    [Export]
    double timeInHitState = 0;

    int currentHit = 0;
    
    public override void Enter()
    {
        currentHit = 0;
        if(parent.hitDirection==Vector2.Right){
            animation = "hitFront";
        }else animation = "hitBack";
        base.Enter();
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
        if(timeInHitState>0.5){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
        
    }

    public void GetHit(int combo){
        parent.Velocity = new Vector2(parent.hitDirection.X*10,0);
        timeInHitState=0;
    }

    public override void Exit()
    {   
        base.Exit();
    }
}
