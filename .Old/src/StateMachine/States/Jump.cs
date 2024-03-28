using Godot;
using System;

public partial class Jump : State
{
    bool isJumping = false;
    float startY = 0.0f;

    float jumpHeight = 48;
    float currentPosition = 0;
    float jumpY = 0;
    float startHeight;


    public override void Enter(){
        base.Enter();
        startHeight = player.height;
        currentPosition = 0;//player.Position.Y;
        jumpY = currentPosition-jumpHeight;
        animationPlayer.Play("jumpBegin"+side);
        //player.SetHeight(player.height+1);
        isJumping = true;
        startY = player.Position.Y;
        //player.Velocity = new Vector2(0,-200);
    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta)
    {
        Vector2 movement = GetMovementInput();
        GetNode<Label>("%currentHeight").Text = currentPosition.ToString();
        player.Velocity = movement*50;
        if(currentPosition<jumpHeight && isJumping){
            currentPosition += 1;
            player.Position -= new Vector2(0,1);
            player.Scale += new Vector2((float)delta/3,(float)delta/3);
        }else{
            isJumping = false;
        }
        if(currentPosition>0 && !isJumping){
            currentPosition -= 1;
            player.Position += new Vector2(0,1);
            player.Scale -= new Vector2((float)delta/3,(float)delta/3);
        }
        if(currentPosition<=0 && !isJumping){
            player.Scale = Vector2.One;
            GD.Print("Land");
            currentPosition = 0;
            player.Velocity = Vector2.Zero;
            EmitSignal(SignalName.transitioned,this,"Idle");
            
        }
        if(player.floor>player.height && currentPosition>32){
            GD.Print("idk");
            currentPosition-=32;
            player.SetHeight(player.height+1);
        }
    }

    public override void Exit(){
        if(player.floor<player.height){
            player.SetHeight(player.floor);
        }
    }

    public void Jumping(){

    }
}
