using Godot;
using System;

public partial class Hud : CanvasLayer {

	private Label pointsLabel;
	private Control winScreen;
	private Control pauseMenu;
	private int points = 0;

	public override void _Ready() {
		pointsLabel = GetNode<Label>("UserBar/HBoxContainer/PointsLabel");
		winScreen = GetNode<Control>("WinScreen");
		pauseMenu = GetNode<Control>("PauseMenu");

		winScreen.Hide();
		pauseMenu.Hide();

		pointsLabel.Text = points.ToString();
	}

	public override void _Input(InputEvent @event){
		if(Input.IsActionJustPressed("ui_pause")){
			TooglePauseMenu();
		}
	}

	public void TooglePauseMenu(){
		pauseMenu.Visible = !pauseMenu.Visible;
		GetTree().Paused = pauseMenu.Visible;
		Input.SetMouseMode(pauseMenu.Visible ? Input.MouseModeEnum.Visible : Input.MouseModeEnum.Captured);
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

	public void _on_resume_button_pressed(){
		TooglePauseMenu();
	}
}
