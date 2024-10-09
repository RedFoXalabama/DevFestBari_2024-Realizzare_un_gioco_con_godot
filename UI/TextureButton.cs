using Godot;
using System;

public partial class TextureButton : Godot.TextureButton
{
	// Path to your Level scene
	private const string LevelScenePath = "res://Level.tscn";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Connect("pressed", new Callable(this, nameof(OnButtonDown)));
	}

	// Function to handle the button press
	private void OnButtonDown() {
		GoToLevel();
	}

	// Function to change the scene to Level.tscn
	private void GoToLevel() {
		// Load the scene
		PackedScene levelScene = (PackedScene)GD.Load("res://Level/Level.tscn");
		if (levelScene != null) {
			// Get the SceneTree and change the scene
			GetTree().ChangeSceneToPacked(levelScene);
		}
		else {
			GD.PrintErr("Failed to load scene: " + "res://Level/Level.tscn");
		}
	}
}
