using Godot;
using System;

public partial class PlayerIdleState : State
{
        public override void Enter(){
        animation = "idle";
        GD.Print(parent.GetActiveItem());
        base.Enter();
    }

    public override void Update(double delta){
        base.Update(delta);
        //if(moveCompontent.direction.X != moveVelocity){
            UpdateAnimation(animation);
        //}
    }

    public override void PhysicsUpdate(double delta)
    {
        
        base.PhysicsUpdate(delta);
        if(parent.Velocity!=Vector2.Zero){
            parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*5);
        }
        if(moveCompontent.WantMove()!=0){
            float moveVelocity = moveCompontent.WantMove() * 100;
            animation = "walk";
            parent.Velocity = new Vector2(moveVelocity,0);
        }
        else animation="idle";
        
        // if(action==Actions.WALK){
        //     EmitSignal(SignalName.transitioned,this,"Walk");
        // }

        if(action==Actions.ATTACK){
            EmitSignal(SignalName.transitioned,this,"Attack");
        }

        if(parent.IsOnFloor() && action==Actions.JUMP){
            EmitSignal(SignalName.transitioned,this,"Jump");
        }
        if(action==Actions.SHOOT){
            EmitSignal(SignalName.transitioned,this,"Shoot");
        }
    }
}
