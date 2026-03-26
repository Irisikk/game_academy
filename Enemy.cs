using Godot;
using System;

public partial class Enemy : Node2D
{

	[Export] public int Health = 100;
	[Export] public Label HealthLabel;

	public void takeddamage(int damage) {
		Health -= damage;
		if (Health <0) Health =0;

		//обнова экрана ёпта
		if (HealthLabel !=null)
			HealthLabel.Text = $"HP: {Health}";

		GD.Print($"враг получил {damage} урона. Осталось: {Health}");

		if (Health <= 0) {
			Die();
		}
	}
	private void Die()
	{ //инет опять блять сдох;
		GD.Print("vrag zdox");
	}
}

