using Godot;
using Microsoft.VisualBasic;
using System;

public partial class Interactable : Node
{
    public virtual void Interact(Node node){
        GD.Print("Interaction with "+Name);
    }
}
