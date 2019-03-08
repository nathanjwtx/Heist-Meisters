using Godot;
using System;

public class SetVariables : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(GetParent().Name);
        SceneTree root = GetTree();
        Global.Destinations = root.CurrentScene.GetNode<Node2D>("GuardNavigation/LevelDestinations");
        Global.GlobalNavigation2D = root.CurrentScene.GetNode<Navigation2D>("GuardNavigation");
        Global.GlobalRandom = new Random();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
