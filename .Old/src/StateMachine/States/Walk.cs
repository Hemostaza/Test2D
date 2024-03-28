using Godot;
using System;

public partial class Walk : State
{
    String animation = "walk";
    public override void Enter(){
        base.Enter();
        animationPlayer.Play(animation+side);
    }

    public override void Update(double delta){
        base.Update(delta);
        //GetAnimationPlayer().Play("walk"+side);
    }

    public override void PhysicsUpdate(double delta)
    {
        Vector2 movement = GetMovementInput();
        player.Velocity = movement * 100;
        // String newSide = side;
        // if(movement.X>0){
        //     newSide = "Right";
        // }
        // else if(movement.X<0){
        //     newSide = "Left";
        // }
        UpdateAnimation();
        //player.UpdateDirection(newSide);

        if(moveCompontent.GetMovementDirection()==Vector2.Zero){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
        if(Input.IsActionJustPressed("fire")){
            EmitSignal(SignalName.transitioned,this,"Punch");
        }
        if(Input.IsActionJustPressed("jump")){
            EmitSignal(SignalName.transitioned,this,"Jump");
        }
    }

    public void UpdateAnimation(){
         if(moveCompontent.direction==Vector2.Right){
            side = "Right";
        }else if (moveCompontent.direction==Vector2.Left){
            side = "Left";
        }
        animationPlayer.Play(animation+side);
    }

    public override void Exit(){
        GD.Print("exit from "+this.Name);
        GD.Print(moveCompontent.lastMotion);
        player.SetSlide(moveCompontent.lastMotion*50);
    }
}
