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
		generateHill(15, 15, new Vector2(400, 65), this);
	}

	public override void _Process(double delta)
	{
		// Called every frame. Delta is time since the last frame.
		// Update game logic here.
	}

	public void generateHill(int height, int lenght, Vector2 startpos, Node scene)
	{
		Random random = new Random();
		Vector2 additionX = new Vector2(30, 0);
		Vector2 additionY = new Vector2(0, 30);
		Vector2 nextPos = startpos;
		for (int h = 0; h <= height; h++)
		{
			for (int l = 0; l < lenght; l++)
			{
				if (random.Next(0, 100) > 45)
				{
					Area2D trash = new Area2D();
					trash.Name = "trash(" + h + ", " + l + ")";
					TextureRect texture = new TextureRect();
					int index = random.Next(0, 3);
					Texture2D texture1 = GD.Load<Texture2D>(locations[index]);
					texture.Texture = texture1;
					trash.AddChild(texture);
					CollisionShape2D collision = new CollisionShape2D();
					collision.Scale = trash.Scale;
					trash.AddChild(collision);
					trash.Position = nextPos;
					scene.AddChild(trash);
				}
				nextPos += additionX;
			}
			startpos -= additionY;
			nextPos = startpos;
		}
	}
}
