using Godot;
using System;
using System.Data;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody2D
{
     [Export]
     private int moveSpeed = 1;
     [Export]
     private Vector2 startDirection = new Vector2(1,0);

    AnimationTree animationTree;
    AnimationNodeStateMachinePlayback stateMachine;

    AnimationPlayer ap;
    Vector2 inputDirection; 
    [Export]
    String direction;

    bool wantAttack;
    [Export]
    double timeInCombat = 0.5;
    double combatTimer = 0.0;

    Vector2 slide = new Vector2(0,0);
    Vector2 chuj = new Vector2(100,0);
Vector2 cipa = new Vector2(0,0);
    float time = 0.0f;

    double slideTime = 0.1;

    TileMap tileMap;
    public float floor =  0;
    public float height = 0;
    public float zIndex = 0;

    public float zPos = 0;
    public override void _Ready()
    {
        wantAttack = false;
        tileMap = (TileMap)GetTree().CurrentScene.FindChild("TileMap");
        GetNode<Label>("%Floor").Text = floor.ToString();
        GetNode<Label>("%Height").Text = floor.ToString();
        ap = GetNode<AnimationPlayer>("AnimationPlayer");
        animationTree = GetNode<AnimationTree>("AnimationTree");
        stateMachine = animationTree.Get("parameters/playback").As<AnimationNodeStateMachinePlayback>();
    }

    public void SetHeight(float value){
        height = value;
        zIndex = value;
        GetNode<Label>("%Height").Text = value.ToString();
    }

    public void SetZPos(float value){
        zPos = value;
        GetNode<Label>("%zPos").Text = value.ToString();
    }

    public void SetFloor(float value){
        floor = value;
        GetNode<Label>("%Floor").Text = value.ToString();
    }

    public void UpdateTile(){
        TileData tData = tileMap.GetCellTileData(0,tileMap.LocalToMap(Position));
        if(tData!=null){
            SetFloor((float)tData.GetCustomData("Height"));
        }
        else SetFloor(0.0f);
    }

	public override void _PhysicsProcess(double delta)
    {
        UpdateTile();
        SetZPos(Position.Y);
        if(slide!=Vector2.Zero){
            slideTime -= delta;
            Velocity = slide;
            if(slideTime<=0){
                Velocity=Vector2.Zero;
                slideTime=0.1;
                slide=Vector2.Zero;
            }
        }

        MoveAndSlide();
    }

    public void UpdateDirection(String newDirection){
        if(!direction.Equals(newDirection)){
            direction=newDirection;
        }
    }
    public String GetDirection(){
        return direction;
    }

    public void SetSlide(Vector2 slide){
        this.slide = slide;
    }
}
