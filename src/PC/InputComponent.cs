using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class InputComponent : Node
{   
    Actions oneAction;
    public Vector2 direction = Vector2.Right;

    [Export]
    InventoryComponent inventoryComponent;
    public float WantMove(){
        float movement = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        // if(movement>0){
        //     direction = Vector2.Right;
        // }else if(movement<0){
        //     direction = Vector2.Left;
        // }
        if (movement!=0) { 
            direction = new Vector2(movement,0);
        }
        return movement;
    }

    public Actions GetInput()
    {
        
        if(WantMove()!=0)  oneAction = (Actions.WALK);
        ItemData activeItem = inventoryComponent.GetActiveItem();
        if(activeItem!=null && activeItem.GetItemFlags().HasFlag(ItemFlag.weapon)){
           if(Input.IsActionJustReleased("fire"))  oneAction = (Actions.SHOOT);
        }else{
            if(Input.IsActionPressed("fire"))  oneAction = (Actions.ATTACK);
            if(Input.IsActionJustReleased("fire"))  oneAction = (Actions.ATTACK_RELEASE);
            if(Input.IsActionJustPressed("fire"))  oneAction = (Actions.ATTACK_PRESSED);
        }
        //GD.Print(player.inventoryComponent.GetActiveItem());

        if(Input.IsActionPressed("jump"))  oneAction = (Actions.JUMP);
        if(Input.IsActionJustReleased("jump"))  oneAction = (Actions.JUMP_RELEASE);
        
        //musi zwraacac idle bez inputa

        return oneAction;
    }

}
