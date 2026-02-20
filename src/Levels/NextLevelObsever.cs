using Godot;
using System;

public partial class NextLevelObsever : Node2D
{
    [Export] private Area2D _detectionArea;
	private bool _detectPlayer;
	private bool _hasItemBeenStolen;

    public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
}
