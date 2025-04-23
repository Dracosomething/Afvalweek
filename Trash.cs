using Godot;
using System;

public partial class Trash : Area2D
{
    	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("down"))
		{
			velocity.Y += 1;
		}


		Position += velocity * (float)delta;
	}
}
