using Godot;
using System;

public partial class BallMovement : CharacterBody2D
{
	public const float Speed = 10.0f;
	Vector2 velocity;
	int direction;
	float angle;
	Main parentNode;

	public override void _Ready()
	{
		//Get the parent (Node2D) node and access it's Main.cs script
		parentNode = (Main)GetParent();
		ResetBall();
	}
	
	public void ResetBall()
	{
		// Reset the position of the ball to the center of the screen
		Position = GetViewportRect().Size / 2;
		
		// Get random direction on the x axis
		direction = GD.RandRange(-1, 1);
		
		// Fail safe option in case the direction returns 0
		if(direction == 0)
		{
			direction = -1;
		}
		
		// Randomize the angle the ball travels in between values
		angle = (float)GD.RandRange(-60.0f, 60.0f);
		
		// Create a new velocity based on the direction and random angle
		velocity = new Vector2(direction * Speed, Mathf.Tan(angle));
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		// Move the ball in a direction (velocity) and check for any collision
		KinematicCollision2D col = MoveAndCollide(velocity);
		
		// When the ball hits a wall, bounce back from it
		if(col != null)
		{
			parentNode.IncreaseScore();
			velocity = velocity.Bounce(col.GetNormal());
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
