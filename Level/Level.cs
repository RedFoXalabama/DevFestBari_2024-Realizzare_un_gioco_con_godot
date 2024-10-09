using Godot;
using System;

public partial class Level : Node3D {

	[Signal] public delegate void UpdateHUDEventHandler();

	private Node mushroomContainer;

	public override void _Ready() {
		mushroomContainer = GetNode("MushroomContainer");

		foreach (Mushroom mushroom in mushroomContainer.GetChildren()) {
			mushroom.Connect(Mushroom.SignalName.MushroomCollected, new Callable(this, nameof(Addpoint)));
		}
	}

	public void Addpoint() {
		EmitSignal(nameof(UpdateHUDEventHandler));
	}

}
