using Godot;
using System;

public partial class Trash : Area2D
{
	public override void _Process(double delta)
	{
		//CollisionShape2D object2D = this.GetNode<CollisionShape2D>("coll");
		//// if (object2D.touc)
		//if (Position.Y <= 65)
		//{
			//Position = new Vector2(
				//x: Position.X,
				//y: Mathf.Clamp(Position.Y, 0, 65)
			//);
		//}
		//else
		//{
			//var velocity = Vector2.Zero;
			//velocity.Y += (float)(10000 * delta);
			//float y = Position.Y;
			//y += (float)(velocity.Y * delta);
			//Position = new Vector2(
				//x: Position.X,
				//y: y
			//);
		//}
	}

	// public override void _Process(double delta)
	// {

	// 	this.Position += velocity * (float)delta;

	// }
}
