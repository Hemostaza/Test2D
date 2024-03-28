using Godot;
using System;

public partial class PlayerMoveComponent : MoveComponent
{   
    public override float GetMovementDirection(){
        float movement = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        if(movement>0){
            direction = Vector2.Right;
        }else if(movement<0){
            direction = Vector2.Left;
        }
        return movement;
    }

    public override bool GetAttackInput(bool isHolding){
        if(isHolding){
            return Input.IsActionPressed("fire");
        }else{
            return Input.IsActionJustPressed("fire");
        }
    }

    public override bool GetJumpInput(bool isHolding)
    {
        if(isHolding){
            return Input.IsActionPressed("jump");
        }else{
            return Input.IsActionJustPressed("jump");
        }
    }

    public override bool IsAttackInputReleased()
    {
        return Input.IsActionJustReleased("fire");
    }

    public override bool IsJumpInputReleased()
    {
        return Input.IsActionJustReleased("jump");
    }
}
