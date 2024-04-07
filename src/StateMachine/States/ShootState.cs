using Godot;
using System;

public partial class ShootState : AttackState
{
    //Odebrac inventorycomponent
    [Export]
    ItemData activeItem; //w tym miejscu to 99% szans że to bedzie weapon ale kto wie czy nie bede chcial dawac im aktywnych itemow w psotaci jabłka czy innego pizdryka

    public override void InitState()
    {
        base.InitState();
    }
    public override void Enter()
    {
        base.Enter();
        activeItem = parent.GetActiveItem();
        GD.Print(parent.GetActiveItem());
    }

    public override void Update(double delta)
    {
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        EmitSignal(SignalName.transitioned,this,"Idle");
    }

    public override void Exit()
    {
        base.Exit();
    }

}
