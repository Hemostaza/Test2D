using Godot;
using System;

public partial class WalkState : State
{
    float moveSpeed = 0;
    public override void Enter(){
        animation = "walk";
        base.Enter();
    }

    public override void Update(double delta){
        base.Update(delta);
        if(moveCompontent.direction.X != moveSpeed){
            UpdateAnimation(animation);
        }
    }

    public override void PhysicsUpdate(double delta){
        base.PhysicsUpdate(delta);
        moveSpeed = moveCompontent.WantMove() * 100;

        parent.Velocity = new Vector2(moveSpeed,0);
        
        if(action==Actions.IDLE){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
        if(action==Actions.ATTACK){
            EmitSignal(SignalName.transitioned,this,"Attack");
        }
        if(action==Actions.JUMP){
            EmitSignal(SignalName.transitioned,this,"Jump");
        }

    }
    public override void Exit(){
        base.Exit();
        parent.Velocity = moveCompontent.direction*50;
    }
}
