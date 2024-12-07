using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public const float Speed = 300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		//Getting the player's W and S input and setting it to the moveY value
		float moveY = Input.GetAxis("Up", "Down") * Speed * (float)delta;
		
		//Move the player
		Translate(new Vector2(0, moveY));
		
		//Move towards the desired location
		velocity.Y = Mathf.MoveToward(0, moveY, Speed);
		
		//Move the player with collision detection
		Velocity = velocity;
		MoveAndSlide();
	}
}
