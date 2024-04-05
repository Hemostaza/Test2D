using Godot;
using System;

public partial class Item : Sprite2D
{
    [Export]
    ItemData itemData;

    public override void _Ready()
    {
        Texture = itemData.texture;
    }

    public ItemData GetItemData(){
        return itemData;
    }
}
