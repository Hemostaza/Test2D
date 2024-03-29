using Godot;
using System;

public partial class Entity : CharacterBody2D
{
    [Export]
    public double safeTimeInAir = 0.3;
    [Export]
    public double attackLenght = 0.4;
    [Export]
    public StateMachine stateMachine;
    public bool isAttacking = false;

    public Vector2 direction = Vector2.Right;
    public String side = "Right";

    public State currentState;
    public override void _PhysicsProcess(double delta)
    {
        Falling();
        MoveAndSlide();
    }

    void Falling(){
        if(!IsOnFloor() && currentState.Name!="Jump" && currentState.Name!="Fall"){
            stateMachine.OnChildTransition(currentState,"Fall");
        }
    }

    public Vector2 hitDirection = Vector2.Zero;
    public virtual void TakeDamage(Vector2 hitDirection, int combo){
        this.hitDirection = hitDirection;
        GD.Print(Name+": Ouch "+hitDirection);
    }

    public void SetCurrentState(State state){
        currentState = state;
    }
}
