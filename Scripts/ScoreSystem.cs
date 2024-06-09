using Godot;
using System;

public partial class ScoreSystem : Node2D
{
	[Export]
	RichTextLabel LeftScoreLabel;
	[Export]
	RichTextLabel RightScoreLabel;
	[Export]
	float WinningScore;

	int PlayerScore;
	int OpponentScore;

	[Export]
	AnimationPlayer PlayerScoreAnimation;
	[Export]
	AnimationPlayer OpponentScoreAnimation;

	public override void _Ready()
	{
		PlayerScore=-1;
		LeftScoreLabel.Text="[/center]0[/center]";
		OpponentScore=-1;
		RightScoreLabel.Text="[center]0[/center]";
	}
	
	private void _on_left_area_entered(Node2D body)
	{
		OpponentScore+=1;
		RightScoreLabel.Text="[center]"+OpponentScore.ToString()+"[/center]";
		OpponentScoreAnimation.Play("WhenScoreUpdatesOpponent");
	}


	private void _on_right_area_entered(Node2D body)
	{
		PlayerScore+=1;
		LeftScoreLabel.Text="[center]"+PlayerScore.ToString()+"[/center]";
		PlayerScoreAnimation.Play("WhenScoreUpdates");
	}

	public override void _PhysicsProcess(double delta)
	{
		if(PlayerScore==WinningScore || OpponentScore==WinningScore)
		{
			GetTree().ChangeSceneToFile("res://MainMenu.tscn");
		}
	}
}



