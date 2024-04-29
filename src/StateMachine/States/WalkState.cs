using Godot;
using System;

public partial class WalkState : State
{
    float moveVelocity = 0;
    public override void Enter(){
        animation = "walk";
        base.Enter();
    }

    public override void Update(double delta){
        base.Update(delta);
        if(parent.GetFacingDirection().X != moveVelocity){
            UpdateAnimation(animation);
        }
    }

    public override void PhysicsUpdate(double delta){
        base.PhysicsUpdate(delta);
        moveVelocity = parent.WantMove() * 100;

        parent.Velocity = new Vector2(moveVelocity,0);
        
        if(action==Actions.IDLE){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
        if(action==Actions.ATTACK){
            EmitSignal(SignalName.transitioned,this,"Attack");
        }
        if(action==Actions.JUMP){
            EmitSignal(SignalName.transitioned,this,"Jump");
        }
        if(action==Actions.SHOOT){
            EmitSignal(SignalName.transitioned,this,"Shoot");
        }

    }
    public override void Exit(){
        base.Exit();
        parent.Velocity = parent.GetFacingDirection()*50;
    }
}
