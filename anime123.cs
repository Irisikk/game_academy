using Godot;
using System;

public partial class anime123 : AnimatedSprite2D
{   

    [ExportCategory("Test")]
    [ExportGroup("Movement_Settings")]
    [ExportSubgroup("Tile_Size")]
    [Export] public int TileSize = 16;
    [ExportSubgroup("Speed")]
    [Export] public float Speed = 300.0f;

    private Vector2 _targetPosition;
    private bool _isMoving = false;

    public override void _Ready()
    {
        Position = Position.Snapped(new Vector2(TileSize, TileSize));
        _targetPosition = Position;
    }

    public override void _Process(double delta)
    {
        if (!_isMoving)
        {
            Vector2 inputDir = Vector2.Zero;

            if (Input.IsActionPressed("moverightTEST")) inputDir.X = 1;
            else if (Input.IsActionPressed("moveleftTEST"))  inputDir.X = -1;
            else if (Input.IsActionPressed("movedownTEST"))  inputDir.Y = 1;
            else if (Input.IsActionPressed("moveupTEST"))    inputDir.Y = -1;

            if (inputDir != Vector2.Zero)
            {
                _targetPosition = Position + inputDir * TileSize;
                _isMoving = true;
                
                Play("right"); 
                if (inputDir.X != 0) FlipH = inputDir.X < 0;
            }
            else 
            {
                Play("idle");
            }
        }
        else
        {
            Position = Position.MoveToward(_targetPosition, Speed * (float)delta);

            if (Position.DistanceTo(_targetPosition) < 0.1f)
            {
                Position = _targetPosition;
                _isMoving = false;
            }
        }
    }
}
