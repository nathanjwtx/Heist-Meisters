using Godot;
using System;
using System.Runtime.CompilerServices;

public class Destinations : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("dest");
        Global.Destinations = this;
    }

//    public void SetGlobalDestinations()
//    {
//        Global.Destinations = this;
//    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
