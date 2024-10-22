using Godot;
using System;

public partial class TextureButton : Godot.TextureButton
{
	// Path della scena Level
	private const string LevelScenePath = "res://Level.tscn";

	// Chiamato quando il nodo entra nella scena per la prima volta
	public override void _Ready() {
		Connect("pressed", new Callable(this, nameof(_on_button_down)));
	}

	// Funzione per il tasto premuto
	private void _on_button_down() {
		GoToLevel();
	}

	// Function to change the scene to Level.tscn
	private void GoToLevel() {
		// Load the scene
		PackedScene levelScene = (PackedScene)GD.Load("res://Gioco Finito/Level/Level.tscn");
		if (levelScene != null) {
			// Get the SceneTree and change the scene
			GetTree().ChangeSceneToPacked(levelScene);
		}
		else {
			GD.PrintErr("Failed to load scene: " + "res://Level/Level.tscn");
		}
	}
}
