using Godot;
using System;

public partial class anime123 : AnimatedSprite2D
{   
    [Export]
    public float Speed = 400.0f;

    private AnimatedSprite2D _animationSprite;

    public override void _Ready()
    {
        
        _animationSprite = this;
    }

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
            
            
            _animationSprite.Play("right");
            
            
            if (velocity.X != 0)
            {
                _animationSprite.FlipH = velocity.X < 0;
            }
        }
        else
        {
        
            _animationSprite.Play("idle");
        }

        
        Position += velocity * (float)delta;
    }
}
