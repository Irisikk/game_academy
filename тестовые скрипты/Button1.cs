using Godot;
using System;

public partial class Button1 : Button
{
	[Export] public LineEdit TargetInput;

	public override void _Ready() {
		
		this.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed() {
		
		GD.Print("knopka epta v godote");


	}
}