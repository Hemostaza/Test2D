using Godot;
using System;

public partial class PPunchState : AttackState
{

    [Export]
    Sprite2D leftArm;
    [Export]
    Sprite2D rightArm;
    [Export]
    double timeForPunching = 0.4;
    double punchTime;
    bool isRight;

    double chargeTime = 0;
    //bool isAttacking;

    public Vector2 target = new Vector2();

    public override void Enter(){
        animation = "punchCharge";
        base.Enter();
        chargeTime=0;
        punchTime = timeForPunching;
        isRight = true;
        isAttacking = false;

    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta){
        Vector2 Pos = parent.GetGlobalMousePosition();
        if(Pos.X<parent.Position.X){
            Pos = parent.Position + (parent.Position - parent.GetGlobalMousePosition());
            moveCompontent.direction=Vector2.Left;
            animationPlayer.Play(animation+side);
            UpdateSide();
        }else if(Pos.X>parent.Position.X){
            moveCompontent.direction=Vector2.Right;
            animationPlayer.Play(animation+side);
            UpdateSide();
        }
        rightArm.LookAt(Pos);
        leftArm.LookAt(Pos);

        Charge(delta);
        if(isAttacking){
            punchTime-=delta;
        }
        if(punchTime<=0){
            animation = "idle";
            animationPlayer.Play(animation+side);
        }
        //Attack(delta);

        // if(punchTime<0){
        //     animationPlayer.Play("idle"+side);
        // }
        if(punchTime<-0.1){
            isAttacking=false;
            EmitSignal(SignalName.transitioned,this,"Idle");
        }

        if(parent.Velocity!=Vector2.Zero){
            parent.Velocity = parent.Velocity.Lerp(Vector2.Zero,(float)delta*10);
        }

    }
    public override void Exit(){
        leftArm.Rotation = 0;
        rightArm.Rotation = 0;
    }

    public void Charge(double delta){
        //jak prawa reka i trzyma LPM
        if(Input.IsActionPressed("fire") && isRight && punchTime<0.05){
            chargeTime+=delta;
            animation = "punchCharge";
            animationPlayer.Play(animation+side);
            isAttacking = false;
        }
        else if(Input.IsActionJustReleased("fire") && isRight && !isAttacking){
            chargeTime=0;
            punchTime=timeForPunching;
            AttackRight();
            isAttacking=true;
        }
        else if(Input.IsActionJustPressed("fire") && !isRight){
            punchTime=timeForPunching;
            isAttacking=true;
            AttackLeft();
        }
    }

    public void Attack(double delta){
        //Atak po puszczeniu guziołka - 
        if(isAttacking){
            punchTime-=delta;
            if(punchTime<0.1){
                SetPunchAnimation();
                isAttacking=false;
            }
        }
    }

    public void AttackRight(){
        GD.Print("AttackRight");
        if (isRight){
            animation = "punch";
            animationPlayer.Play(animation+side);
            isRight=false;
        }
    }

    public void AttackLeft(){
        GD.Print("AttackLeft");
        if(!isRight){
            animation = "punchContinue";
            animationPlayer.Play(animation+side);
            isRight=true;
        }
    }
    public void SetPunchAnimation(){

        UpdateSide();
            if (isRight){
                animationPlayer.Play("punch"+side);
                isRight=false;
            }
            else if(!isRight){
                animationPlayer.Play("punchContinue"+side);
                isRight=true;
            //punchTime=timeForPunching;
        }
    }

}
