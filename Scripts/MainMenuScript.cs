using Godot;
using System;

public partial class MainMenuScript : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void StartGame()
	{
		// GetTree().ChangeSceneToFile("res://Game.tscn");
	}

	void OnPlayButtonPressed()
	{
		GD.Print("lets go");
		GetTree().ChangeSceneToFile("res://Game.tscn");
	}

	void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}
