using Godot;
using System;

public partial class Entity : CharacterBody2D
{
    [Export]
    public double safeTimeInAir = 0.3;
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
}
