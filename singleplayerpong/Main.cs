using Godot;
using System;

public partial class Main : Node2D
{
		int score = 0;
	Label scoreText;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		scoreText = GetNode<Label>($"CanvasLayer/Label");
	}

	public void IncreaseScore()
	{
		score++;
		GD.Print("Increased Score");
		
		//Setting the Label's text to the current score
		scoreText.SetText("Score: " + score.ToString());
	}
}
