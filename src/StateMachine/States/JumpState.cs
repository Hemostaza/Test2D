using Godot;
using System;

public partial class JumpState : State
{
    [Export]
    double jumpForce = 200;
    [Export]
    double chargeMultiplier = 1;
    [Export]
    bool instant = false;
    double timeToJump = 0;
    double chargForce = 0;
    public override void Enter(){
        animation = "jumpCharge";
        base.Enter();
        chargForce = 0;
        //parent.Velocity += new Vector2(0,(float)-jumpForce);
    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta){
        base.PhysicsUpdate(delta);
        timeToJump+=delta;
        if(parent.Velocity!=Vector2.Zero && parent.IsOnFloor()){
            parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*5);
        }
        if(action==Actions.JUMP){
            if(chargForce<1){
                chargForce+=delta;
            }
        }
        else if(action==Actions.JUMP_RELEASE || (instant && timeToJump>0.15)){
            timeToJump=0;
            float movement = parent.WantMove();
            parent.Velocity += new Vector2(movement*40,(float)-jumpForce-(float)chargForce*(float)chargeMultiplier);
            UpdateAnimation("jump");
            EmitSignal(SignalName.transitioned,this,"Fall");
        }
    }
    public override void Exit(){
        timeToJump=0;
        base.Exit();
    }
}
