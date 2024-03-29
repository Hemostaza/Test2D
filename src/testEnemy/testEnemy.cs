using Godot;
using System;

public partial class testEnemy : Entity
{
    [Export]
    EnemyAI moveComponent;

    int maxHit = 3;

    public override void TakeDamage(Vector2 hitDirection, int combo)
    {
        base.TakeDamage(hitDirection, combo);
        GetHitState hitState = stateMachine.GetStates()["GetHit"] as GetHitState;
        if(hitState==null){
            return;
        }
        stateMachine.ChangeState("GetHit");
        hitState.GetHit( combo);
    }

}
