using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Characters
{
    public class Guard : PlayerDetection
    {
        [Export] public int WalkSlowdown;
        
        public Vector2 Motion;
        public Vector2 Destination;
        private Node2D _destinations;
        private Navigation2D _navigation2D;
        private List<object> _possible_destinations = new List<object>();
        private List<Vector2> _path = new List<Vector2>();

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _possible_destinations = _destinations.GetChildren().ToList();
            MakePath();
        }

        public Guard()
        {
            _destinations = Global.Destinations;
            _navigation2D = Global.Navigation2D;
        }

        private void MakePath()
        {
            _path = _navigation2D.GetSimplePath();
        }
        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
        //  public override void _Process(float delta)
        //  {
        //      
        //  }
    }
}