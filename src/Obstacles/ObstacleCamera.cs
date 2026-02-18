using System;
using Godot;
using MacEwanGameJam26.Players;

namespace MacEwanGameJam26.Obstacles;

[Tool]
public partial class ObstacleCamera : Node2D
{
    [Signal]
    public delegate void OnPlayerDetectedEventHandler();

    [Export] private Area2D _detectionArea;
    private float _detectionTime;
    private bool _hasPlayerBeenDetected;
    private bool _isPlayerBeingDetected;

    [Export] private float _timeToDetectionSec = 2f;

    public override void _Ready()
    {
        if (_detectionArea is null)
        {
            CustomLogger.LogError("_detectionArea is null");
            return;
        }

        _detectionArea.BodyEntered += OnAreaEntered;
        _detectionArea.BodyExited += OnAreaExited;
    }

    public override void _Process(double delta)
    {
        if (_isPlayerBeingDetected && !_hasPlayerBeenDetected)
        {
            _detectionTime += (float)GetProcessDeltaTime();
            if (_detectionTime >= _timeToDetectionSec) DetectPlayer();
        }
        else
        {
            // Decay detection time
            _detectionTime -= (float)GetProcessDeltaTime() * 0.5f;
        }

        _detectionTime = Math.Clamp(_detectionTime, 0, _timeToDetectionSec);
    }

    public override string[] _GetConfigurationWarnings()
    {
        if (_detectionArea is null)
            return ["_detectionArea is null"];
        return [];
    }

    private void DetectPlayer()
    {
        _hasPlayerBeenDetected = true;
        EmitSignalOnPlayerDetected();
        CustomLogger.LogDebug($"Player detected by {Name} ({GetType().Name})");
    }

    private void OnAreaEntered(Node2D node)
    {
        if (node is not Player)
            return;
        _isPlayerBeingDetected = true;
    }

    private void OnAreaExited(Node2D node)
    {
        if (node is not Player)
            return;
        _isPlayerBeingDetected = false;
    }
}