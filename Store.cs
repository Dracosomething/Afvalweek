using Godot;
using System;

public partial class Store : ColorRect
{
    

	public void onInteract() {
		var store = GetNode<ColorRect>("store");
		store.visible = true;
	}

    
}
