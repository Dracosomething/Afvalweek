using Godot;
using System;

public partial class MainScene : ColorRect
{
	public override void _Ready()
	{
		Sprite2D nodeToAdd = new Sprite2D(); // Your node to add
		nodeToAdd.Name = "Test123";
		Texture2D texture = new Texture2D();
		texture.ResourcePath = "Screenshot 2024-11-28 174135.png";
		nodeToAdd.Texture = texture;
		nodeToAdd.Position = this.Position;
		AddChild(nodeToAdd);
		GD.Print(nodeToAdd.GetParent().Name);
	}
}
