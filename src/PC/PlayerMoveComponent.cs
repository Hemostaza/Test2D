using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PlayerMoveComponent : MoveComponent
{   
    [Export]
    pc player;
    public override float WantMove(){
        float movement = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        if(movement>0){
            direction = Vector2.Right;
        }else if(movement<0){
            direction = Vector2.Left;
        }
        return movement;
    }

    public override bool WantAttackPress(bool isHolding){
        if(isHolding){
            return Input.IsActionPressed("fire");
        }else{
            return Input.IsActionJustPressed("fire");
        }
    }

    public override bool WantJump(bool isHolding)
    {
        if(isHolding){
            return Input.IsActionPressed("jump");
        }else{
            return Input.IsActionJustPressed("jump");
        }
    }

    public override bool WantAttackRelease()
    {
        return Input.IsActionJustReleased("fire");
    }

    public override bool WantJumpRelease()
    {
        return Input.IsActionJustReleased("jump");
    }

    public override List<Actions> GetActions()
    {
        ItemData activeItem = player.GetActiveItem();
        actions = new List<Actions>();
        if(activeItem!=null && activeItem.GetItemFlags().HasFlag(ItemFlag.weapon)){
           if(Input.IsActionJustReleased("fire")) actions.Add(Actions.SHOOT);
        }else{
            if(Input.IsActionPressed("fire")) actions.Add(Actions.ATTACK);
            if(Input.IsActionJustReleased("fire")) actions.Add(Actions.ATTACK_RELEASE);
            if(Input.IsActionJustPressed("fire")) actions.Add(Actions.ATTACK_PRESSED);
        }
        //GD.Print(player.inventoryComponent.GetActiveItem());

        if(Input.IsActionPressed("jump")) actions.Add(Actions.JUMP);
        if(Input.IsActionJustReleased("jump")) actions.Add(Actions.JUMP_RELEASE);
        if(WantMove()!=0) actions.Add(Actions.WALK);
        
        if(!actions.Any()){
            actions.Add(Actions.IDLE);
        }
        return actions;
    }
}
