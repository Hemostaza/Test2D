using Godot;
using System;

public partial class Item : Node
{
    public ItemFlag itemFlags;
    public override void _Ready()
    {
        base._Ready();
    }
}

[Flags]
public enum ItemFlag{
    isPickable,
    isUsable,
    Food,
}
