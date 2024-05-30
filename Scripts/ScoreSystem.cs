using Godot;
using System;

public partial class ScoreSystem : Node2D
{
	[Export]
	RichTextLabel LeftScoreLabel;
	[Export]
	RichTextLabel RightScoreLabel;

	int PlayerScore;
	int OpponentScore;

	public override void _Ready()
	{
		PlayerScore=11;
		LeftScoreLabel.Text="11";
		OpponentScore=11;
		RightScoreLabel.Text="11";
	}
	
	private void _on_left_area_entered(Node2D body)
	{
		PlayerScore-=1;
		LeftScoreLabel.Text=PlayerScore.ToString();
		GD.Print("bruh");
	}


	private void _on_right_area_entered(Node2D body)
	{
		OpponentScore-=1;
		RightScoreLabel.Text=OpponentScore.ToString();
		GD.Print("bruh");
	}

	public override void _PhysicsProcess(double delta)
	{
		if(PlayerScore==0 || OpponentScore==0)
		{
			GetTree().ChangeSceneToFile("res://MainMenu.tscn");
			GD.Print("Game over");
		}
	}
}



