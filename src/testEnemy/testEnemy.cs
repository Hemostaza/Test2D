using Godot;
using System;

public partial class testEnemy : Entity
{
    int maxHit = 3;
    [Export]
    public Entity target;
    [Export]
    AIComponent enemyAI;


    public override void _Ready()
    {
        base._Ready();
    }
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
            if(stateMachine.GetCurrentState()!=hitState && !stateMachine.GetCurrentState().Name.Equals("HitFall")){
                //currentState = hitState;
                stateMachine.ChangeState("GetHit");
            }
            hitState.GetHit(power, hitDirection);
        }
    }

    public override Actions GetAction()
    {
        return enemyAI.IWantJumpLol();
    }

    public override float WantMove()
    {
        return enemyAI.WantMove();
    }
    public override Vector2 GetFacingDirection()
    {
        return new Vector2(enemyAI.WantMove(),0);
    }

}
