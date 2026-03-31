using Godot;
using System;

public partial class Enemy : AnimatedSprite2D
{
    [ExportGroup("Movement_Settings")]
    [Export] public int TileSize = 16;
    [Export] public float Speed = 200.0f;
    [Export] public Node2D Player; 

    private Vector2 _targetPosition;
    private bool _isMoving = false;

    public override void _Ready()
    {
        Position = Position.Snapped(new Vector2(TileSize, TileSize));
        _targetPosition = Position;
        
        AddToGroup("Enemy");
    }

    public override void _Process(double delta)
    {
        if (!_isMoving)
        {
            // (заметка для себя на будущее) проверка на ход противника
            
            MoveTowardsPlayer();
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

    private void MoveTowardsPlayer()
    {
        if (Player == null) return;

        
        Vector2 diff = Player.Position - Position;
        Vector2 moveDir = Vector2.Zero;

        
        if (Mathf.Abs(diff.X) > TileSize / 2f)
        {
            moveDir.X = Mathf.Sign(diff.X);
        }
        else if (Mathf.Abs(diff.Y) > TileSize / 2f)
        {
            moveDir.Y = Mathf.Sign(diff.Y);
        }

        if (moveDir != Vector2.Zero)
        {
            Vector2 nextStep = Position + moveDir * TileSize;

        
            Vector2 snappedPlayerPos = Player.Position.Snapped(new Vector2(TileSize, TileSize));
            
            if (nextStep != snappedPlayerPos && !IsTileOccupied(nextStep))
            {
                _targetPosition = nextStep;
                _isMoving = true;
                
                
                Play("walk"); 
                FlipH = moveDir.X < 0;
            }
            else
            {
                
                Play("idle");
            }
        }
    }

    private bool IsTileOccupied(Vector2 targetPos)
    {
        var enemies = GetTree().GetNodesInGroup("Enemy");
        foreach (Node2D enemy in enemies)
        {
            if (enemy != this && enemy.Position.DistanceTo(targetPos) < 1.0f)
            {
                return true;
            }
        }
        return false;
    }
}