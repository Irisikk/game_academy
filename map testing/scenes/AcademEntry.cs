using Godot;
using System;

public partial class AcademEntry : Area2D
{
    private void OnAreaEntered(Area2D area)
    {
        GD.Print(area);
    }
}
