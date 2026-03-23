using Godot;
using System;

public partial class MeshInstance2d2 : MeshInstance2D
{
	public override void _Ready()
	{
		Position = Position with { X = 100.0f };
	}
}
