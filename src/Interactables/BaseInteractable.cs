using Godot;
using MacEwanGameJam26.Interfaces;
using MacEwanGameJam26.Players;

namespace MacEwanGameJam26.Interactables;

public partial class BaseInteractable : Area2D, IInteractable
{
    public virtual void Interact(Player interactor)
    {
    }
}