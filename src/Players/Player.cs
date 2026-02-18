using Godot;
using MacEwanGameJam26.Levels;

namespace MacEwanGameJam26.Players;

public partial class Player : CharacterBody2D
{
    [Export] private LevelMoneyController _moneyController;
}