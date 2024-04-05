using Godot;
using System;

public partial class SlotData : Node
{
    [Export]
    public Sprite2D itemSprite;

    public void UpdateSlot(Item item){
        GD.Print("Update slot:"+item);
        ItemData itemData = item.GetItemData();
        if(item==null){
            itemSprite.Visible = false;
        }
        else{
            itemSprite.Visible = true;
            itemSprite.Texture = itemData.texture;
        }
    }
}
