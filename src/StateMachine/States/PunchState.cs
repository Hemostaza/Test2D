using Godot;
using System;
using System.Diagnostics;

public partial class PunchState : AttackState
{
    [Export]
    Sprite2D rightArm;
    [Export]
    Sprite2D leftArm;

    bool isRight;
    double chargeTime;
    bool isCharging;

    public override void Enter(){
        animation="punchCharge";
        base.Enter();
        isRight=true;
        chargeTime = 0;
        isAttacking = false;
        isCharging = true;
    }

    public override void Update(double delta){
        base.Update(delta);
        UpdateArmRotation();
    }
    public override void PhysicsUpdate(double delta){
        base.PhysicsUpdate(delta);

        if(isCharging){
            chargeTime+=delta;
        }

        ProcessInput(delta);
    }

    public override void Exit(){
        base.Exit();
        leftArm.Rotation = 0;
        rightArm.Rotation = 0;
    }

    public void ProcessInput(double delta){
        //jak prawa reka i trzyma LPM
        if(Input.IsActionJustPressed("fire") && !isCharging && !isAttacking ){
            isCharging = true;
        }
        else if(Input.IsActionPressed("fire") && isRight && isCharging){
            attackLenght = 0.5;
            //animation = "punchCharge";
            UpdateAnimation("punchCharge");//animationPlayer.Play(animation+side);
        }
        else if(!Input.IsActionPressed("fire") && isRight && chargeTime>0.1 && !isAttacking ){
            isCharging=false;
            chargeTime=0;
            Attack(isRight);
        }
        else if(Input.IsActionJustPressed("fire") && !isRight && attackLenght<0.3){
            Attack(isRight);
        }
    }

    public void Attack(bool isRight){
        if (isRight){
            animation = "punch";
            animationPlayer.Play(animation+side);
            this.isRight=false;
        }else{
            animation = "punchContinue";
            animationPlayer.Play(animation+side);
            this.isRight=true;
        }
        attackLenght = 0.4;
        isAttacking = true;
    }

    void UpdateArmRotation(){
        Vector2 Pos = parent.GetGlobalMousePosition();
        
        rightArm.LookAt(Pos);
        leftArm.LookAt(Pos);

        if(Pos.X<parent.Position.X){

            rightArm.Rotate(3.14f);
            leftArm.Rotate(3.14f);

            moveCompontent.direction=Vector2.Left;
            
        }else if(Pos.X>parent.Position.X){
            moveCompontent.direction=Vector2.Right;
            
        }
        UpdateAnimation(animation);
    }
}
