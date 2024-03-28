using Godot;
using System;

public abstract partial class MoveComponent : Node
{
    public Vector2 direction = Vector2.Right;

    abstract public float GetMovementDirection();
    abstract public bool GetAttackInput(bool isPressed);
    abstract public bool IsAttackInputReleased();

    abstract public bool GetJumpInput(bool isPressed);

    abstract public bool IsJumpInputReleased();

}