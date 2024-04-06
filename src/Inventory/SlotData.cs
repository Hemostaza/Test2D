using Godot;
using System;

public partial class SlotData : TextureRect
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

    public void SetActiveSlot(){
        (Texture as AtlasTexture).Region = new Rect2(0,0,16,16);
    }

    public void SetInactiveSlot(){
        (Texture as AtlasTexture).Region = new Rect2(16,0,16,16);
    }
}
