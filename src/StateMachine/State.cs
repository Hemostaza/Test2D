using Godot;
using System;

public partial class State : Node
{
    public Entity parent;

    public String side;
    public String animation;

    [Signal]
    public delegate void transitionedEventHandler(State state, String newStateName);

    public AnimationPlayer animationPlayer;
    public String animationGroup;
    String fullAnimationName;
    public MoveComponent moveCompontent;

    virtual public void Enter(){
        UpdateAnimation(animation);
         GD.Print("enter: "+this.Name);
    }

    virtual public void Exit(){
        GD.Print("Exit: "+this.Name);
    }

    virtual public void Update(double delta){
    }

    virtual public void PhysicsUpdate(double delta){
    }

    public void UpdateSide(){
        if(moveCompontent.direction==Vector2.Right){
            side = "Right";
        }
        else if(moveCompontent.direction==Vector2.Left){
            side = "Left";
        }
    }
    
    public float GetMovementInput(){
        return moveCompontent.GetMovementDirection();
    }
    
    public void UpdateAnimation(String animation){
        UpdateSide();
        this.animation = animation;
        fullAnimationName = animationGroup+"/"+animation+side;
        if(animationPlayer.GetAnimation(fullAnimationName)!=null){
            animationPlayer.Play(fullAnimationName);
        }
    }
    public void AnimationQueue(String animation){
        UpdateSide();
        this.animation = animation;
        fullAnimationName = animationGroup+"/"+animation+side;
        GD.Print(fullAnimationName);
        if(animationPlayer.GetAnimation(fullAnimationName)!=null){
            animationPlayer.Queue(fullAnimationName);
        }
    }
}
