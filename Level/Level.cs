using Godot;
using System;

public partial class Level : Node3D {

	[Signal] public delegate void UpdateHUDEventHandler();
	[Signal] public delegate void WinHUDEventHandler();

	private Node mushroomContainer;

	public override void _Ready() {
		mushroomContainer = GetNode("MushroomContainer");

		foreach (Mushroom mushroom in mushroomContainer.GetChildren()) {
			mushroom.Connect(Mushroom.SignalName.MushroomCollected, new Callable(this, nameof(Addpoint)));
		}
	}

    public override void _Process(double delta) {
        if (mushroomContainer.GetChildCount() == 0) {
			EmitSignal(nameof(WinHUD));
		}
    }

    public void Addpoint() {
		EmitSignal(nameof(UpdateHUD));
	}

}
