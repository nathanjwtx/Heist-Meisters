using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using Godot.Collections;

namespace Characters
{
    public class Guard : PlayerDetection
    {
        [Export] public float WalkSlowdown;
        [Export] public float navStopThreshold;
        
        public Vector2 Motion;
        public Vector2 Destination;
        private Node2D _destinations;
        private Navigation2D _navigation2D;
        private readonly List<Vector2> _possibleDestinations = new List<Vector2>();
//        private List<Node> _possible_destinations;
        private List<Vector2> _path = new List<Vector2>();

        public override void _Ready()
        {
            _destinations = Global.Destinations;
            _navigation2D = Global.GlobalNavigation2D;
            foreach (Position2D position2 in _destinations.GetChildren())
            {
                _possibleDestinations.Add(position2.GlobalPosition);
            }
//            _possible_destinations = new Array<Node>(_destinations.GetChildren()).ToList();
//            _possible_destinations = (from node2d in GetChildren().Cast<Node2D>() select node2d.Position).ToList();
            MakePath();
        }

        public override void _Process(float delta)
        {
            Navigate();
        }

        private void Navigate()
        {
            float distToDestination = Position.DistanceTo(_path[0]);
            Destination = _path[0];

            if (distToDestination > navStopThreshold)
            {
                Move();
            }
            else
            {
                UpdatePath();
            }
        }

        private void Move()
        {
            LookAt(Destination);
            Motion = (Destination - Position).Normalized() * (MAX_SPEED * WalkSlowdown);
            MoveAndSlide(Motion);
        }
        
        private void MakePath()
        {
            Vector2 nextDestination = _possibleDestinations[Global.GlobalRandom.Next() % _possibleDestinations.Count];
            _path = _navigation2D.GetSimplePath(GlobalPosition, nextDestination).ToList();
            
        }

        private void UpdatePath()
        {
            if (_path.Count == 1)
            {
                if (GetNode<Timer>("Timer").IsStopped())
                {
                    GetNode<Timer>("Timer").Start();
                }
            }
            else
            {
                _path.Remove(_path[0]);
            }
        }
        
        private void _on_Timer_timeout()
        {
            // Replace with function body.
        }
    }
}


