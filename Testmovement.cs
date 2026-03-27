using Godot;
using System;

public partial class Testmovement : Node2D
    
{   
    [Export]
    public float Speed = 400.0f;

    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Zero;

    
        if (Input.IsActionPressed("moverightTEST")) velocity.X += 1;
        if (Input.IsActionPressed("moveleftTEST"))  velocity.X -= 1;
        if (Input.IsActionPressed("movedownTEST"))  velocity.Y += 1;
        if (Input.IsActionPressed("moveupTEST"))    velocity.Y -= 1;

        
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }

    
        Position += velocity * (float)delta;
    }
}
