using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400;
	[Export]
	public Camera2D camera { get; set; }
	[Export]
	public Label score { get; set; }

	public Vector2 ScreenSize;
	private Vector2 mousePos;

	enum ShovelType
	{
		FLIMSY,
		REGULAR,
		ADVANCED
	}

	private Inventory bag;
	double GroundPos = 240.5;

	public override void _Ready()
	{
		ScreenSize = new Vector2(3350, 1000);
		bag = new Inventory(1000);
		score.Text = "trash collected: 0/" + bag._capasity;
		score.SetAnchorsPreset(Control.LayoutPreset.TopLeft);
	}

	public override void _Process(double delta)
	{
		movement(delta);
		_break();
		if (!Input.IsActionPressed("up"))
		{
			Vector2 velocity = new Vector2(0, 210);
			this.Position += velocity * (float)delta;
			if (Position.Y <= GroundPos)
			{
				Position = new Vector2(
					x: Position.X,
					y: Mathf.Clamp(Position.Y, -732, 209)
				);
			}
			else
			{
				velocity = Vector2.Zero;
				velocity.Y += (float)(10000 * delta);
				float y = Position.Y;
				y += (float)(velocity.Y * delta);
				Position = new Vector2(
					x: Position.X,
					y: y
				);
			}
		}
	}

	private void movement(double delta)
	{
		this.camera.Position = this.Position;
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("left"))
		{
			velocity.X -= 1;
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
			y: Mathf.Clamp(Position.Y, -732, ScreenSize.Y)
		);

		if (velocity.X != 0)
		{
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.FlipH = velocity.X > 0;
		}
	}

	private void _break()
	{
		if (this.GetOverlappingAreas().Count > 0)
		{
			if (Input.IsActionPressed("click"))
			{
				foreach (Area2D trash in GetOverlappingAreas())
				{
					if (trash != this)
					{
						trash.QueueFree();
						if (bag.addTrash())
						{
							score.Text = $"trash collected: {bag._contents}/{bag._capasity}";
						}
					}
				}
			}
		}
	}
}
