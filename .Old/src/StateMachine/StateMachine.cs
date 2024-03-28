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
    MoveComponent moveComponent;
    
    [Export]
    Player player;
    State currentState;
    Dictionary<String, State> states = new Dictionary<string, State>();
    public override void _Ready()
    {
        foreach (State child in GetChildren()){

            if(child.GetType().IsSubclassOf(typeof(State))){
                states[child.Name] = child;
                child.player = player;
                child.transitioned += OnChildTransition;
                child.animationPlayer = animationPlayer;
                child.moveCompontent = moveComponent;
            }
        }
        if(initialState!=null){
            initialState.Enter();
            currentState = initialState;
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
        GD.Print(newStateName);
        if(state!=currentState){
            return;
        }
        State newState = states[newStateName];
        if(newState==null){
            return;
        }
        if(currentState!=null){
            currentState.Exit();
            
        }
        
        newState.Enter();
        currentState = newState;
    }
}
