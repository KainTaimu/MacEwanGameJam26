using System.Linq;
using Godot;
using MacEwanGameJam26.Interfaces;

namespace MacEwanGameJam26.Players;

public partial class PlayerInteractionController : Area2D
{
    private bool _hasInteracted;

    // How long to hold to count as interact
    [Export] private float _holdTimeUntilInteract = 0.5f;

    // How long the interact button has been held
    private float _interactHoldDuration;
    [Export] private Player _player;

    public override void _Process(double delta)
    {
        if (GetOverlappingAreas().Count == 0)
        {
            _interactHoldDuration = 0;
            _hasInteracted = false;
            return;
        }

        if (Input.IsActionPressed("Interact"))
        {
            _interactHoldDuration += (float)delta;

            if (_interactHoldDuration >= _holdTimeUntilInteract && !_hasInteracted)
            {
                Interact();
                _hasInteracted = true;
            }

            if (!_hasInteracted)
                CustomLogger.LogDebug(_interactHoldDuration);
        }
        else
        {
            _hasInteracted = false;
            _interactHoldDuration = 0;
        }
    }

    private void Interact()
    {
        var area = GetOverlappingAreas().FirstOrDefault();
        if (area is not IInteractable interactable)
            return;

        interactable.Interact(_player);
    }

    private void OnArea2DEntered(Area2D area)
    {
    }
}