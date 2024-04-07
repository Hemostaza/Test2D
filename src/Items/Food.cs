using Godot;
using System;
[GlobalClass]
public partial class Food : ItemData
{
    [Export]
    int hpREgen = 2;

    public override void UseItem()
    {
        base.UseItem();
        GD.Print(hpREgen);
    }
}
