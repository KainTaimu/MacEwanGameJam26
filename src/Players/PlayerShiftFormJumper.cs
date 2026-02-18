using Godot;

namespace MacEwanGameJam26.Players;

public partial class PlayerShiftFormJumper : PlayerShiftForm
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed(ActionShortcutName))
            Shift(this);
    }
}