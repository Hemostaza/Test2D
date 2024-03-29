using Godot;
using System;
using System.Diagnostics;

public partial class PunchState : AttackState
{
    [Export]
    Sprite2D rightArm;
    [Export]
    Sprite2D leftArm;
    [Export]
    Area2D area2D;
    bool isRight;
    double chargeTime;
    bool isCharging;

    int damage = 0;
    int combo = 0;

    public override void Enter(){
        combo = 0;
        area2D.Monitoring = false;
        animation="punchCharge";
        damage = 1;
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
        area2D.Monitoring = false;
        leftArm.Rotation = 0;
        rightArm.Rotation = 0;
    }

    public void ProcessInput(double delta){
        //jak prawa reka i trzyma LPM
        if(moveCompontent.GetActions().Contains(Actions.ATTACK_PRESSED) && !isCharging && !isAttacking ){
            isCharging = true;
        }
        else if(moveCompontent.GetActions().Contains(Actions.ATTACK) && isRight && isCharging){
            attackLenght = 0.5;
            //animation = "punchCharge";
            UpdateAnimation("punchCharge");//animationPlayer.Play(animation+side);
        }
        else if(!moveCompontent.GetActions().Contains(Actions.ATTACK) && isRight && chargeTime>0.1 && !isAttacking ){
            isCharging=false;
            chargeTime=0;
            Attack();
        }
        else if(moveCompontent.GetActions().Contains(Actions.ATTACK_PRESSED) && !isRight && attackLenght<0.3){
            Attack();
        }
    }

    public void Attack(){
        area2D.Monitoring = true;
        if (isRight){
            animation = "punch";
            //animationPlayer.Play(animation+side);
            isRight=false;
        }else{
            animation = "punchContinue";
            //a/nimationPlayer.Play(animation+side);
            isRight=true;
        }
        attackLenght = parent.attackLenght;
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

    void OnPunchHitBodyEnter(Node2D body){
        Vector2 isFront = moveCompontent.direction;
        if(body.HasMethod("TakeDamage")){
            combo += 1;
            if(combo>=3){
                combo = 0;
            }
            Entity character = body as Entity;
            GD.Print(isFront);
            // if(moveCompontent.direction!=character.direction){
            //     isFront = moveCompontent.direction;
            // }
            character.TakeDamage(isFront, combo);
        }
    }
}
