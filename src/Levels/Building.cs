using Godot;

namespace MacEwanGameJam26.Levels;

public partial class Building : Node2D
{
    [Export] private Sprite2D _exteriorSprite;
    [Export] private Sprite2D _interiorSprite;
    [Export] private Area2D _playerInteriorArea;

    public override void _Ready()
    {
    }

    private void OnPlayerExitBuilding(Node2D body)
    {
        CustomLogger.LogDebug("Exit");
        _exteriorSprite.Show();
        _interiorSprite.Hide();
    }

    private void OnPlayerEnterBuilding(Node2D body)
    {
        CustomLogger.LogDebug("Enter");
        _exteriorSprite.Hide();
        _interiorSprite.Show();
    }
}