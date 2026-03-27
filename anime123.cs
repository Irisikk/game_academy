using Godot;
using System;

public partial class anime123 : AnimatedSprite2D
{   
    [Export]
    public float Speed = 400.0f;

    private AnimatedSprite2D _animationSprite;

    public override void _Ready()
    {
        // Инициализируем ссылку на самого себя
        _animationSprite = this;
    }

    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        // Сбор ввода
        if (Input.IsActionPressed("moverightTEST")) velocity.X += 1;
        if (Input.IsActionPressed("moveleftTEST"))  velocity.X -= 1;
        if (Input.IsActionPressed("movedownTEST"))  velocity.Y += 1;
        if (Input.IsActionPressed("moveupTEST"))    velocity.Y -= 1;

        if (velocity.Length() > 0)
        {
            // Нормализуем один раз
            velocity = velocity.Normalized() * Speed;
            
            // Проигрываем анимацию бега
            _animationSprite.Play("right");
            
            // Отражаем спрайт, если идем влево
            if (velocity.X != 0)
            {
                _animationSprite.FlipH = velocity.X < 0;
            }
        }
        else
        {
            // Включаем idle, только если движения нет
            _animationSprite.Play("idle");
        }

        // Применяем движение
        Position += velocity * (float)delta;
    }
}
