using Godot;
using System;

public partial class State : Node
{
    public Player player;

    public String side;

    [Signal]
    public delegate void transitionedEventHandler(State state, String newStateName);

    public AnimationPlayer animationPlayer;
    public MoveComponent moveCompontent;

    virtual public void Enter(){
        
        GetNode<Label>("%stateLabel").Text = this.Name;
        
        if(moveCompontent.direction==Vector2.Right){
            side = "Right";
        }else if (moveCompontent.direction==Vector2.Left){
            side = "Left";
        }
    }

    virtual public void Exit(){
    }

    virtual public void Update(double delta){
    }

    virtual public void PhysicsUpdate(double delta){

    }
    
    public Vector2 GetMovementInput(){
        return moveCompontent.GetMovementDirection();
    }
}
