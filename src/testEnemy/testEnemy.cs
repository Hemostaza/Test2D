using Godot;
using System;

public partial class testEnemy : Entity
{
    int maxHit = 3;

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        
        Falling();
    }

    public override void TakeDamage(Vector2 hitDirection, double power) //można przeciazyc no jo xD
    {
        base.TakeDamage(hitDirection, power);
        
        if(IsOnFloor()){
            GetHitState hitState = stateMachine.GetStates()["GetHit"] as GetHitState;
            if(hitState==null){
                return;
            }
            if(currentState!=hitState && !currentState.Name.Equals("HitFall")){
                //currentState = hitState;
                stateMachine.ChangeState("GetHit");
            }
            hitState.GetHit(power);
        }
    }

}
