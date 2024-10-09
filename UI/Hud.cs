using Godot;
using System;

public partial class Hud : CanvasLayer {

	private Label pointsLabel;
	private int points = 0;

	public override void _Ready() {
		pointsLabel = GetNode<Label>("Control/HBoxContainer/PointsLabel");

		pointsLabel.Text = points.ToString();
	}

	private void _on_level_update_hud(){
		points++;
		pointsLabel.Text = points.ToString();
	}

}
