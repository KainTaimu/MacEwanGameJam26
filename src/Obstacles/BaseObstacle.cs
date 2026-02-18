using System;
using Godot;
using MacEwanGameJam26.Interfaces;

namespace MacEwanGameJam26.Obstacles;

public partial class BaseObstacle : Node2D, IInteractable
{
    public void Interact()
    {
        throw new NotImplementedException();
    }
}