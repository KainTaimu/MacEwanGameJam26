using Godot;
using MacEwanGameJam26.Interactables;
using MacEwanGameJam26.Levels;
using MacEwanGameJam26.Players;

namespace MacEwanGameJam26.scenes.Interactables;

public partial class InteractableValuable : BaseInteractable
{
    [Export] private LevelMoneyController _moneyController;
    [Export] private Label _onStealLabel;
    [Export] public int MonetaryValue = 10;

    public override void Interact(Player interactor)
    {
        CustomLogger.LogDebug($"Got {Name}");
        _moneyController.MoneyStolen += MonetaryValue;

        _onStealLabel.Show();

        // Show the "+$XX" text.
        var tween = CreateTween().SetEase(Tween.EaseType.Out);
        tween.Parallel().TweenProperty(_onStealLabel,
            "position",
            _onStealLabel.Position + Vector2.Up * 100,
            1f);
        tween.Parallel().TweenProperty(this, "modulate", Colors.Transparent, 1f);
        tween.TweenCallback(Callable.From(QueueFree));
    }
}