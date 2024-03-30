using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
    [Export]
    State initialState;
    [Export]
    AnimationPlayer animationPlayer;
    [Export]
    String animationGroup;
    [Export]
    MoveComponent moveComponent;
    [Export]
    Entity parent;
    State currentState;
    Dictionary<String, State> states = new Dictionary<string, State>();
    public override void _Ready()
    {
        foreach (State child in GetChildren()){

            if(child.GetType().IsSubclassOf(typeof(State))){
                states[child.Name] = child;
                child.parent = parent;
                child.transitioned += OnChildTransition;
                child.animationPlayer = animationPlayer;
                child.animationGroup = animationGroup;
                child.moveCompontent = moveComponent;
            }
        }
        if(initialState!=null){
            initialState.Enter();
            currentState = initialState;
            parent.SetCurrentState(currentState);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if(currentState!=null){
            currentState.PhysicsUpdate(delta);
        }
    }

    public override void _Process(double delta)
    {
        if(currentState!=null){
            currentState.Update(delta);
        }
    }

    public void OnChildTransition(State state, String newStateName)
    {
        if(state!=currentState){
            return;
        }
        ChangeState(newStateName);
    }

    public void ChangeState(String newStateName){
        State newState = states[newStateName];
        
        if(newState==null){
            return;
        }
        if(currentState!=null){
            currentState.Exit();
        }
        
        newState.Enter();
        currentState = newState;
        parent.SetCurrentState(currentState);
    }

    public Dictionary<String, State> GetStates(){
        return states;
    }
}
