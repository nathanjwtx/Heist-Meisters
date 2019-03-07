using Godot;
using System;

namespace Characters
{
    public class Player : Character
    {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        private Vector2 _motion;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _motion = new Vector2();
            Global.Player = this;
        }

        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            UpdateMotion(delta);
            MoveAndSlide(_motion);
        }

        private void UpdateMotion(float delta)
        {
            LookAt(GetGlobalMousePosition());

            if (Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down"))
            {
                _motion.y = Mathf.Clamp(_motion.y - SPEED, -MAX_SPEED, 0);
            }
            else if (Input.IsActionPressed("ui_down") && !Input.IsActionPressed("ui_up"))
            {
                _motion.y = Mathf.Clamp(_motion.y + SPEED, 0, MAX_SPEED);
            }
            else
            {
                _motion.y = Mathf.Lerp(_motion.y, 0, FRICTION);
            }

            if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right"))
            {
                _motion.x = Mathf.Clamp(_motion.x - SPEED, -MAX_SPEED, 0);
            }
            else if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left"))
            {
                _motion.x = Mathf.Clamp(_motion.x + SPEED, 0, MAX_SPEED);
            }
            else
            {
                _motion.x = Mathf.Lerp(_motion.x, 0, FRICTION);
            }
        }
    }
}