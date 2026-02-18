using System;
using Godot;
using Godot.Collections;
using MacEwanGameJam26.Interfaces;
using MacEwanGameJam26.Players;

namespace MacEwanGameJam26.Levels;

public partial class BaseObstacle : Node2D, IInteractable
{
    [Export] public Array<StringName> AllowedFormNames;

    public void Interact(Player player)
    {
        throw new NotImplementedException();
    }
}