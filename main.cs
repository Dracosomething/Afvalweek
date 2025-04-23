using Godot;
using System;
using System.Collections.Generic;

public partial class main : Node
{
	List<string> locations = ["res://art/Modular_Afval_1.png", "res://art/Modular_Afval_2.png", "res://art/Modular_Afval_3.png", "res://art/Modular_Afval_4.png"];

	public override void _Ready()
	{
		// Called every time the node is added to the scene.
		// Initialization here.
		GD.Print("Hello from C# to Godot :)");
		GD.Print();
		generateHill(5, this);
	}

	public override void _Process(double delta)
	{
		// Called every frame. Delta is time since the last frame.
		// Update game logic here.
	}

	public void generateHill(int itterations, Node scene) {
		Random random = new Random();
		for (int i = 0; i <= itterations; i++) {
			Area2D trash = new Area2D();
			trash.Name = "trash" + i;
			TextureRect texture = new TextureRect();
			Texture2D texture2D = new Texture2D();
			int index = random.Next(0, 3);
			texture2D.ResourcePath = locations[index];
			texture.Texture = texture2D;
			trash.AddChild(texture);
			CollisionShape2D collision = new CollisionShape2D();
			collision.Scale = trash.Scale;
			trash.AddChild(collision);
		}
	}
}
