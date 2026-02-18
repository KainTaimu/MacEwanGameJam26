using Godot;
using MacEwanGameJam26.Interfaces;

namespace MacEwanGameJam26.Interactables;

public partial class BaseInteractable : Area2D, IInteractable
{
    public virtual void Interact()
    {
    }
}