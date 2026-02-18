using System;
using Godot;
using MacEwanGameJam26.Interfaces;
using MacEwanGameJam26.Players;

namespace MacEwanGameJam26.Obstacles;

public partial class BaseObstacle : Node2D, IInteractable
{
    public void Interact(Player interactor)
    {
        throw new NotImplementedException();
    }
}