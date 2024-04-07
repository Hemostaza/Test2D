using Godot;
using System;

public partial class AttackState : State
{
    [Export]
    public double attackLenght=0.4;
    public bool isAttacking;

    public override void Enter(){
        attackLenght = parent.attackLenght;
        base.Enter();
    }

    public override void Update(double delta){
        base.Update(delta);
    }
    public override void PhysicsUpdate(double delta){

        if(parent.Velocity!=Vector2.Zero){
            parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*7);
        }
        attackLenght-=delta;
        
        if(attackLenght<=0.1)
        {
            isAttacking=false;
        }
        if(attackLenght<=0){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
    }

    public override void Exit(){
    }
}
