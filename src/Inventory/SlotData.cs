using Godot;
using System;

public partial class SlotData : TextureRect
{
    [Export]
    public Sprite2D itemSprite;

    Rect2 inactiveRect = new Rect2(16,0,16,16);
    Rect2 activeRect = new Rect2(0,0,16,16);

    public void UpdateSlot(Item item){
        ItemData itemData = item.GetItemData();
        if(item==null){
            itemSprite.Visible = false;
        }
        else{
            itemSprite.Visible = true;
            itemSprite.Texture = itemData.texture;
        }
    }

    public void SetActiveSlot(){
        (Texture as AtlasTexture).Region = activeRect;
    }

    public void SetInactiveSlot(){
        (Texture as AtlasTexture).Region = inactiveRect;
    }
}
