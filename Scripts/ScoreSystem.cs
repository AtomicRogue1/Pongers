using Godot;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

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

	[Signal]
	public delegate void GameIsOverEventHandler(string WhoWon);

	// [Header("Freeze Frame")]
	bool ScreenFreeze;

	public override void _Ready()
	{
		Input.MouseMode=Input.MouseModeEnum.ConfinedHidden;
		ScreenFreeze=false;

		PlayerScore=-1;
		LeftScoreLabel.Text="[/center]0[/center]";
		OpponentScore=-3;
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

	private void GameOverFunc(string WhoWon)
	{
		GD.Print("Game over!" + WhoWon + "won!");
	}

	public override void _PhysicsProcess(double delta)
	{
		if(PlayerScore==WinningScore || OpponentScore==WinningScore)
		{
			// Emit Signal to Ball for Freeze Frame + Game Over UI (use await for time stuff)
			EmitSignal(SignalName.GameIsOver,PlayerScore>WinningScore ? "Red Won!" : "Blue Won!");

			GetTree().ChangeSceneToFile("res://MainMenu.tscn");
		}

		// For pausing game
		if(Input.IsActionJustPressed("Pause"))
		{
			Engine.TimeScale=!ScreenFreeze ? 0: 1;
			Input.MouseMode=!ScreenFreeze ? Input.MouseModeEnum.Visible : Input.MouseModeEnum.ConfinedHidden;
			ScreenFreeze=!ScreenFreeze;
		}
	}
}



