using Godot;
using System;
using System.Collections.Generic;

public abstract partial class MoveComponent : Node
{
    public Vector2 direction = Vector2.Right;

    public List<Actions> actions;

    abstract public float WantMove();
    abstract public bool WantAttackPress(bool isPressed);
    abstract public bool WantAttackRelease();

    abstract public bool WantJump(bool isPressed);

    abstract public bool WantJumpRelease();

    abstract public List<Actions> GetActions();

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
    }