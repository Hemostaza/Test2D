using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class EnemyMoveComponent : MoveComponent
{
    Vector2 targetPosition;
    Entity target;
    testEnemy parent;

    public void SetParent(testEnemy parent){
        this.parent = parent;
    }

    public override float WantMove()
    {
        float movement;
        movement = TargetDirection();

        if(movement>0){
            direction = Vector2.Right; // wyjebac?
            //parent.SetFacingDirection(Vector2.Right);
        }else if(movement<0){
            direction = Vector2.Left; // wyjebac?
            //parent.SetFacingDirection(Vector2.Left);
        }
        return movement;
    }

    public float TargetDirection(){
        if(target==null){
            return 0;
        }
        Vector2 dirX = target.Position - parent.Position;
        return dirX.Normalized().X;
    }

    public void SetTarget(Entity target){
        this.target = target;
    }
    public void SetTarget(Vector2 target){
        targetPosition = target;
    }

}
