using Godot;
using System;

public partial class AcademEntry : Area2D
{
    [Export]
    public SceneTree retx;
    public Node scene = ResourceLoader.Load<PackedScene>("res://map testing/scenes/intern_academy.tscn").Instantiate();
    [Export]
    public String pathtosome = "res://plug.tscn";

    private bool ent = false;

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("interact") && ent) Enter(); 
    }
    
    private void Enter()
    {
        GD.Print("HUIBLYAT");
        // GetTree().UnloadCurrentScene();
        // GD.Print("123123123123 IM EXIST"); // this exist after unload scene ¯\_(ツ)_/¯ 
        // AddChild(scene);
        // GetTree().ChangeSceneToFile("res://map testing/scenes/intern_academy.tscn");
        GetTree().ChangeSceneToFile(pathtosome);
        // GD.Print("123123123123 IM EXIST"); // this exist after unload scene ¯\_(ツ)_/¯ 
        // ProcessMode = ProcessModeEnum.Disabled;
        // GetTree().Paused = true; // this idk
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
