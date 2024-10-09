using Godot;
using System;

public partial class Mushroom : Node3D{

	[Signal] public delegate void MushroomCollectedEventHandler();
	
	public void _on_area_3d_body_entered(Node body){
		if(body.IsInGroup("Player")){
			EmitSignal(nameof(MushroomCollectedEventHandler));
			QueueFree();
		}
	}
}
