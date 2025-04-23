using Godot;
using System;

public partial class CameraControls : Camera2D
{
	private Node2D player;

	public override void _Ready()
	{
		// Called every time the node is added to the scene.
		// Initialization here.
		player = GetParent<Node2D>();
	}

	public override void _Process(double delta)
	{
		// Called every frame. Delta is time since the last frame.
		// Update game logic here.
		this.Position = player.Position;
	}
}
