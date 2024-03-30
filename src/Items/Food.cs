using Godot;
using System;

public partial class Food : Item
{
    public override void _Ready()
    {
        itemFlags = ItemFlag.isPickable | ItemFlag.Food;
        base._Ready();
    }
    
}
