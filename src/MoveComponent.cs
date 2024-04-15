using Godot;
using System;
using System.Collections.Generic;

public abstract partial class MoveComponent : Node
{
    public Vector2 direction = Vector2.Right;

    public List<Actions> actions;

    public Actions oneAction;

    public Actions GetOneAction(){
        GD.Print(oneAction);
        return oneAction;
    }

    public void SetOneAction(Actions action){
        oneAction = action;
    }

    abstract public float WantMove();

}
public enum Actions {
        IDLE,
        WALK,
        ATTACK,
        ATTACK_PRESSED,
        ATTACK_RELEASE,
        JUMP,
        JUMP_RELEASE,
        FALL,
        GETHIT,
        PICKUP,
        SHOOT,
        CROUCH,
    }