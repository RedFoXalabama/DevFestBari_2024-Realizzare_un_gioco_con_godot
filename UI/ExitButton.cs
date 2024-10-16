using Godot;
using System;

public partial class ExitButton : Godot.TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Connect("pressed", new Callable(this, nameof(OnButtonDown)));
	}

	// Function to handle the button press
	private void OnButtonDown() {
		QuitGame();
	}

	// Function to quit the game
	private void QuitGame() {
		GetTree().Quit();
	}
}
