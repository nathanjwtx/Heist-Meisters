using Godot;
using System;
using Characters;

public class Global : Node
{
    public static Player Player;
    public static Navigation2D GlobalNavigation2D;
    public static Node2D Destinations;
    public static SceneTree GlobalSceneTree;
    public static Random GlobalRandom;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        base._Process(delta);
        if (Input.IsActionPressed("ui_cancel"))
        {
            GetTree().Quit();
        }
    }
}
