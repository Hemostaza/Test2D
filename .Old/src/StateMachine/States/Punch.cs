using Godot;
using System;
using System.Threading.Tasks;

public partial class Punch : State
{
    bool isComplete = false;
    bool isContinued = false;

    [Export]
    double timeForPunching = 0.2;
    double punchTime;

    public override void Enter(){
        punchTime = timeForPunching;
        base.Enter();
        isComplete = false;
        isContinued = false;
        animationPlayer.Play("punch"+side);
        player.SetSlide(moveCompontent.direction);
    }

    public override void Update(double delta){
        base.Update(delta);
    }

    public override void PhysicsUpdate(double delta)
    {
        punchTime-=delta;

        if(moveCompontent.GetAttackInput()){
                SetPunchAnimation();
        }
        if(punchTime<0){
            animationPlayer.Play("idle"+side);
        }
        if(punchTime<-0.1){
            EmitSignal(SignalName.transitioned,this,"Idle");
        }
        GetMovementInput();
    }

    public void SetPunchAnimation(){

        if(moveCompontent.direction==Vector2.Right){
            side = "Right";
        }else if (moveCompontent.direction==Vector2.Left){
            side = "Left";
        }

        if(punchTime<0.1){
            if (isContinued){
                animationPlayer.Play("punch"+side);
                isContinued=false;
            }
            else if(!isContinued){
                animationPlayer.Play("punchContinue"+side);
                isContinued=true;
            }
            punchTime=timeForPunching;
        }
        player.SetSlide(moveCompontent.direction);
    }
}
