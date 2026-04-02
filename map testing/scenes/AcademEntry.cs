using Godot;
using System;

public partial class AcademEntry : Area2D
{
    private bool ent = false;

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("interact") && ent) Enter(); 
    }
    
    private void Enter()
    {
        GD.Print("HUIBLYAT");    
        ProcessMode = ProcessModeEnum.Disabled;
    }

    private void OnAreaEntered(Area2D area)
    {
        ent = true;
        GD.Print(area);
        GD.Print("HHHHHHHH");
    }

    private void OnAreaExited(Area2D area)
    {
        ent = false;
        GD.Print(area);
    }
}
