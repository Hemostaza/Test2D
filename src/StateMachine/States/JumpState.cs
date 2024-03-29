using Godot;
using System;

public partial class JumpState : State
{
    [Export]
    double jumpForce = 200;
    [Export]
    double chargeMultiplier = 1;
    double chargForce = 0;
    public override void Enter(){
        animation = "jump";
        base.Enter();
        chargForce = 0;
        //parent.Velocity += new Vector2(0,(float)-jumpForce);
    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta){
        base.PhysicsUpdate(delta);
        if(action==Actions.JUMP){
            if(chargForce<1){
                chargForce+=delta;
                //animation = "jumpCharge";
                UpdateAnimation("jumpCharge");
            }
            //if(moveCompontent.GetMovementDirection()==0.0){
                if(parent.Velocity!=Vector2.Zero){
                    parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*5);
                }
            //}
        }
        else if(action==Actions.JUMP_RELEASE){
            float movement = moveCompontent.WantMove();
            parent.Velocity += new Vector2(movement*40,(float)-jumpForce-(float)chargForce*(float)chargeMultiplier);
            EmitSignal(SignalName.transitioned,this,"Fall");
        }
    }
    public override void Exit(){
        base.Exit();
    }
}
