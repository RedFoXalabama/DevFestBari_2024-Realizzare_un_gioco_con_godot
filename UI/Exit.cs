using Godot;
using System;

public partial class Exit : Godot.TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Connect("pressed", new Callable(this, nameof(on_exit_button_down)));
	}

	// Function to handle the button press
	private void on_exit_button_down() {
		QuitGame();
	}

	// Function to quit the game
	private void QuitGame() {
		GetTree().Quit();
	}
}
