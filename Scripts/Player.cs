using Godot;
using System;
using System.Numerics;

public partial class Player : Sprite2D
{
	[Export]
	Node2D Ceiling;
	[Export]
	Node2D Floor;
	[Export]
	float CollisionOffset = 20f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Godot.Vector2 mousePos = GetViewport().GetMousePosition();
		if (Ceiling.Position.Y+CollisionOffset <= mousePos.Y && mousePos.Y <= Floor.Position.Y-CollisionOffset)
		{
			Position = new Godot.Vector2(Position.X, mousePos.Y);
		}
		else
		{
			// Will remain static
		}
	}
}
