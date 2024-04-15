using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PlayerMoveComponent : MoveComponent
{   
    [Export]
    InventoryComponent inventoryComponent;
    public override float WantMove(){
        float movement = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        if(movement>0){
            direction = Vector2.Right;
        }else if(movement<0){
            direction = Vector2.Left;
        }
        return movement;
    }
    internal void GetInput()
    {
        ItemData activeItem = inventoryComponent.GetActiveItem();
        if(activeItem!=null && activeItem.GetItemFlags().HasFlag(ItemFlag.weapon)){
           if(Input.IsActionJustReleased("fire"))  oneAction = (Actions.SHOOT);
        }else{
            if(Input.IsActionPressed("fire"))  oneAction = (Actions.ATTACK);
            if(Input.IsActionJustReleased("fire"))  oneAction = (Actions.ATTACK_RELEASE);
            if(Input.IsActionJustPressed("fire"))  oneAction = (Actions.ATTACK_PRESSED);
        }
        //GD.Print(player.inventoryComponent.GetActiveItem());

        if(WantMove()!=0)  oneAction = (Actions.WALK);
        if(Input.IsActionPressed("jump"))  oneAction = (Actions.JUMP);
        if(Input.IsActionJustReleased("jump"))  oneAction = (Actions.JUMP_RELEASE);
        
        if(!actions.Any()){
            oneAction = Actions.IDLE;
        }
    }

}
