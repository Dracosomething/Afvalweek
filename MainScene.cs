using Godot;
using System;

public partial class MainScene : ColorRect
{
	public override void _Ready()
	{
		Node nodeToAdd = new Node(); // Your node to add
		nodeToAdd.Name = "Test123";
		AddChild(nodeToAdd);
	}
}
