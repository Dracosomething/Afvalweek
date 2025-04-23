using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400;

	public Vector2 ScreenSize;

	enum ShovelType
	{
		FLIMSY,
		REGULAR,
		ADVANCED
	}

	private Inventory bag;

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("up"))
		{
			velocity.Y -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}
		
		Position += velocity * (float)delta;
		Position = new Vector2(
		x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
		y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
		
		if (velocity.X != 0)
		{
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.FlipH = velocity.X > 0;
		}
	}
}
