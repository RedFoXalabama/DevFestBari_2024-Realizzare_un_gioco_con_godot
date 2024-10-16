using Godot;
using System;

public partial class Hud : CanvasLayer {

	private Label pointsLabel;
	private Control winScreen;
	private int points = 0;

	public override void _Ready() {
		pointsLabel = GetNode<Label>("UserBar/HBoxContainer/PointsLabel");
		winScreen = GetNode<Control>("WinScreen");

		winScreen.Hide();

		pointsLabel.Text = points.ToString();
	}

	public void _on_level_update_hud(){
		points++;
		pointsLabel.Text = points.ToString();
	}

	public void _on_win_hud(){
		GetTree().Paused = true;
		Input.SetMouseMode(Input.MouseModeEnum.Visible);
		winScreen.Show();
	}

	public void _on_restart_button_pressed(){
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}

}
