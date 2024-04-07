using Godot;
using System;

[GlobalClass]
public partial class ItemData : Resource
{
    [Export]
    public ItemFlag itemFlags;
    [Export]
    public String name = "";
    [Export]
    public AtlasTexture texture;
    
    public ItemFlag GetItemFlags(){
        return itemFlags;
    }

    public override string ToString()
    {
        return name;
    }

    public virtual void UseItem(){
    }
}

[Flags]
public enum ItemFlag{
    none = 0,
    isPickable = 2,
    isUsable = 4,
    stackable = 8,
    food = 16,
    weapon = 32,
}
