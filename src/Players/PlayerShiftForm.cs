using Godot;

namespace MacEwanGameJam26.Players;

public partial class PlayerShiftForm : Node
{
    [Export] protected PlayerShapeShiftingController ShiftingController;
    [Export] public string FormName { get; private set; }
    [Export] public StringName ActionShortcutName { get; private set; }

    protected void Shift(PlayerShiftForm newForm)
    {
        ShiftingController.CurrentForm = newForm;
    }
}