using Godot;
using System;

public partial class Button2000 : Button
{
	[Export] public Enemy TargetEnemy;
	[Export] public int DamageUron = 25;

	public override void _Ready()
	{
		this.Pressed += OnAttackPressed;
	}

	private void OnAttackPressed()
	{
		if (TargetEnemy !=null)
		{
			TargetEnemy.takeddamage(DamageUron);			
		}
		else
		{
			GD.PrintErr("NU PIZDEC");
		}
	}
}
