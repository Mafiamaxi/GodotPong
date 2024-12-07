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
	
	private void ResetScore()
	{
		score = 0;
		
		//Setting the Label's text to the current score
		scoreText.SetText("Score: " + score.ToString());
	}
	
	private void OnAreaEntered(Node2D otherNode)
	{
		//Getting the node that collided with the Area2D as a BallMovement
		BallMovement ball = otherNode as BallMovement;
		
		//Check to see if what we collided with is a ball
		//If it is a ball, then we reset the ball and score
		if(ball != null)
		{
			ball.ResetBall();
			ResetScore();
			GD.Print("EnteredArea");
		}
	}
}
