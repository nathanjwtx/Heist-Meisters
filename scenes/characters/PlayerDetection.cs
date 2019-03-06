using Godot;
using System;
using System.Diagnostics.CodeAnalysis;
using Godot.Collections;
using Characters;

public class PlayerDetection : Character
{
    /* this is the absolute of half the angle of the torch sprite/image */
    private int FOV_Tolerance = 23;
    private int MAX_Range = 320;

    private Player _player;

    public override void _Ready()
    {
        SceneTree root = GetTree();
        _player = root.CurrentScene.GetNode<Player>("Player");
        PlayerIsInLOS();
    }

    public override void _Process(float delta)
    {
        Player_In_FOV();
    }

    private void Player_In_FOV()
    {
        Vector2 NPC_Dir = new Vector2(1, 0).Rotated(GlobalRotation);
        Vector2 DirToPlayer = (_player.Position - GlobalPosition).Normalized();

        if (Math.Abs(DirToPlayer.AngleTo(NPC_Dir)) < Mathf.Deg2Rad(FOV_Tolerance) && PlayerIsInLOS())
        {
            GetNode<Light2D>("Torch").Color = Colors.Red;
        }
        else
        {
            GetNode<Light2D>("Torch").Color = Colors.ForestGreen;
        }
    }

    private bool PlayerIsInLOS()
    {
        Physics2DDirectSpaceState space = GetWorld2d().DirectSpaceState;
        Godot.Collections.Array exclude = new Godot.Collections.Array {this};
        Dictionary LOS_Obstacle = space.IntersectRay(GlobalPosition, _player.GlobalPosition, exclude, CollisionMask);
        float DistToPlayer = _player.GlobalPosition.DistanceTo(GlobalPosition);
        bool PlayerInRange = DistToPlayer < MAX_Range;
        
        if (LOS_Obstacle["collider"] == _player && PlayerInRange)
        {
            return true;
        }
        return false;
    }
}
