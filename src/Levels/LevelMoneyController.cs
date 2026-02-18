using Godot;

namespace MacEwanGameJam26.Levels;

public partial class LevelMoneyController : Node
{
    [Export] private Label _moneyStolenLabel;

    public int MoneyStolen
    {
        get;
        set
        {
            field = value;
            _moneyStolenLabel.Text = $"Money Stolen: ${value}";
        }
    } = 0;
}