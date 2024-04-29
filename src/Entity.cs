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
    
    ItemData activeItem;
    
    public Actions action;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    public void Falling(){
        if(!IsOnFloor() && stateMachine.GetCurrentState().Name!="Jump" && stateMachine.GetCurrentState().Name!="Fall"
            && stateMachine.GetCurrentState().Name!="HitFall"){
            stateMachine.OnChildTransition(stateMachine.GetCurrentState(),"Fall");
        }
    }

    public virtual void TakeDamage(Vector2 hitDirection, double power){
        //this.hitDirection = hitDirection;
    }
    //Ustawienie aktywnego itemu
    public virtual void SetActiveItem(ItemData itemData){
        activeItem = itemData;
    }
    public virtual ItemData GetActiveItem(){
        return null;
    }

    public virtual Vector2 GetFacingDirection(){
        return Vector2.Zero;
    }

    public virtual void SetFacingDirection(Vector2 direction){
        
    }

    public virtual void SetAction(Actions action){
        this.action = action;
    }
    public virtual Actions GetAction(){
        return action;
    }

    public virtual float WantMove(){
        return 0;
    }
}
