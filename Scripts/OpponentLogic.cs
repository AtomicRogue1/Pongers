using Godot;
using System;

public partial class OpponentLogic : Sprite2D
{
	[Export]
	float moveSpeed;
	[Export]
	Node2D ball;
	[Export]
	int randomChasingOffset;
	[Export]
	int updateTime;
	// [Export]
	// int step;

	double currentTime;
	int dir;
	int chasingOffset;

	public override void _Ready()
	{
		dir=0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		updateTimer(delta);
		if(ball.GlobalPosition.X < GlobalPosition.X)
		{
		if (ball.GlobalPosition.Y-chasingOffset > GlobalPosition.Y)
		{
			dir=1;
		}
		else if (ball.GlobalPosition.Y+chasingOffset < GlobalPosition.Y)
		{
			dir=-1;
		}
		else
		{
			dir=0;
		}
		}
		else
		dir=0;

		GlobalPosition+=new Vector2(0,(float)delta*dir*moveSpeed);
		GD.Print(chasingOffset);
	}

	void updateTimer(double del)
	{
		Random random=new Random();
		if(currentTime>=updateTime)
		{
		chasingOffset = random.Next(0, randomChasingOffset);
		currentTime=0;
		}
		currentTime+=del;
	}
}
