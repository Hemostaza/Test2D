using Godot;
using System;
using System.Collections.Generic;

public partial class EnemyAI : MoveComponent
{
    public override List<Actions> GetActions()
    {
        List<Actions> actions = new List<Actions>();
        actions.Add(Actions.IDLE);
        return actions;
    }

    public override bool WantAttackPress(bool isPressed)
    {
        throw new NotImplementedException();
    }

    public override bool WantAttackRelease()
    {
        throw new NotImplementedException();
    }

    public override bool WantJump(bool isPressed)
    {
        throw new NotImplementedException();
    }

    public override bool WantJumpRelease()
    {
        throw new NotImplementedException();
    }

    public override float WantMove()
    {
        direction=Vector2.Left;
        return -1;
        //throw new NotImplementedException();
    }

}
