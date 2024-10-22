using Godot;
using System;

public partial class Level : Node3D {

	[Signal] public delegate void UpdateHUDEventHandler();
	[Signal] public delegate void WinHUDEventHandler();

	private Node3D mushroomContainer;
	private AudioStreamPlayer3D eatSound;

	public override void _Ready() {
		mushroomContainer = GetNode<Node3D>("MushroomContainer");
		eatSound = GetNode<AudioStreamPlayer3D>("Player/EatSound");

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
		eatSound.Play();
	}

}
