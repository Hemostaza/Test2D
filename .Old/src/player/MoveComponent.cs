using Godot;
using System;

public partial class MoveComponent : Node
{
    public Vector2 direction = new Vector2(1,0);
    public Vector2 lastMotion = Vector2.Zero;

    public Vector2 GetMovementDirection(){
        Vector2 movement = new Vector2(Input.GetActionStrength("right") - Input.GetActionStrength("left"),
        Input.GetActionStrength("down") - Input.GetActionStrength("up"));
        if(movement.X>0){
            direction = Vector2.Right;
        }else if(movement.X<0){
            direction = Vector2.Left;
        }
        if(movement!=Vector2.Zero){
            lastMotion=movement;
        }
        return movement;
    }

    public bool GetAttackInput(){
        return Input.IsActionJustPressed("fire");
    }
}
