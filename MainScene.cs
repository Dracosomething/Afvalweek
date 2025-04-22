using Godot;
using System;

public partial class MainScene : ColorRect
{
	public override void _ready()
	{
		GD.Print(this.name);
	}
}
