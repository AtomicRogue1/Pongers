using Godot;
using System;

public partial class TrailMakingScript : Line2D
{
	[Export]
	int length=50;

	Vector2 point;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition=Vector2.Zero;
		GlobalRotation=0;

		Node2D ball=GetParent() as Node2D;
		point=ball.GlobalPosition;

		AddPoint(point);
		while(GetPointCount()>length)
		{
			RemovePoint(0);
		}
	}
}
