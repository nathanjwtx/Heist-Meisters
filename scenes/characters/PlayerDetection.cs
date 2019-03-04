using Godot;
using System;

public class PlayerDetection : Character
{
    /* this is the absolute of half the angle of the torch sprite/image */
    private int FOV_Tolerance = 23;

    private Player _player;

    public override void _Ready()
    {
        SceneTree root = GetTree();
        _player = root.CurrentScene.GetNode<Player>("Player");
    }

    public override void _Process(float delta)
    {
        Player_In_FOV();
    }

    public void Player_In_FOV()
    {
        Vector2 NPC_Dir = new Vector2(1, 0).Rotated(GlobalRotation);
        Vector2 DirToPlayer = (_player.Position - GlobalPosition).Normalized();

        if (Math.Abs(DirToPlayer.AngleTo(NPC_Dir)) < Mathf.Deg2Rad(FOV_Tolerance))
        {
            GD.Print("I see you");
        }
    }
}
