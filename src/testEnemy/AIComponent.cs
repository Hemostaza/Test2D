using Godot;
using System;

public partial class AIComponent : Node
{
    Actions currentAction;
    
    [Export]
    Entity target;
    double jumpTimer = 0;
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        //currentAction = Actions.IDLE;
        
        // if(jumpTimer<=0){
        //     currentAction = Actions.IDLE;
        // }
        // jumpTimer+=delta;
        // if(jumpTimer>1){
        //     currentAction = Actions.JUMP; 
        //     GD.Print("Jump");
        //     jumpTimer=-1;
        // }
    }

    public void LookingForTarget(){
        if(target!=null){
            WantMove();
        }
    }

    public Actions IWantJumpLol(){
        return currentAction;
    }

    public float WantMove(){
        currentAction = Actions.WALK;
        return -1;
    }
    public void ToIdle(){
        currentAction = Actions.IDLE;
    }
}
