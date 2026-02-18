using System;
using Godot;

namespace MacEwanGameJam26.Players;

public partial class PlayerMovementController : Node
{
    private float _gravityAcceleration = 9.81f * 100;
    [Export] private float _moveSpeed = 1600f;
    [Export] private Player _player;


    public override void _Process(double delta)
    {
        HandleMovement();
        ApplyGravity();
        _player.MoveAndSlide();
    }

    private void ApplyGravity()
    {
        var downVec = _gravityAcceleration;
        _player.Velocity = new Vector2(_player.Velocity.X, downVec);
    }

    private void HandleMovement()
    {
        var left = Input.IsActionPressed("MoveLeft") ? 1 : 0;
        var right = Input.IsActionPressed("MoveRight") ? 1 : 0;

        float inputX = right - left;

        var moveLength = (float)Math.Sqrt(inputX * inputX);

        if (moveLength > 0)
            inputX /= moveLength;

        var move = new Vector2(
            inputX * _moveSpeed,
            0
        );

        _player.Velocity = move;
    }
}