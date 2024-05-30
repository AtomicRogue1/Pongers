using Godot;
using System;
using System.Runtime.Serialization;

public partial class Ball : RigidBody2D
{
    [Export]
    float DefaultSpeed = 50f;
    [Export]
    RichTextLabel opponentScore;
    [Export]
    RichTextLabel playerScore;

    public override void _Ready()
    {
        // Godot.Vector2 direction = new Godot.Vector2(,)
        // Godot.Vector2 direction = new Godot.Vector2(RandomNumberGenerator.);
        LinearVelocity = new Godot.Vector2(-1, 1) * DefaultSpeed;
    }

    public override void _Process(double delta)
    {
    }

    public void Reset()
    {

    }

}
