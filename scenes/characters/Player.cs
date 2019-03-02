using Godot;
using System;

public class Player : Character
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private Vector2 _motion; 

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        UpdateMotion(delta);
        MoveAndSlide(_motion);
    }

    private void UpdateMotion(float delta)
    {
        if (Input.IsActionJustPressed("ui_up"))
        {
            _motion.x += delta;
            Position = _motion;
        }
    }
}
