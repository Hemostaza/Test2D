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
    public State currentState;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    public void Falling(){
        if(!IsOnFloor() && currentState.Name!="Jump" && currentState.Name!="Fall"
            && currentState.Name!="HitFall"){
            stateMachine.OnChildTransition(currentState,"Fall");
        }
    }

    public Vector2 hitDirection = Vector2.Zero;
    public virtual void TakeDamage(Vector2 hitDirection, double power){
        this.hitDirection = hitDirection;
    }

    public void SetCurrentState(State state){
        currentState = state;
    }
}
