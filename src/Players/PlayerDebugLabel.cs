using Godot;

namespace MacEwanGameJam26.Players;

public partial class PlayerDebugLabel : Label
{
    [Export] private PlayerShapeShiftingController _shiftingController;

    public override void _Ready()
    {
        Text = $"CurrentForm: {_shiftingController.CurrentForm.FormName}";
        _shiftingController.OnFormChanged += (_, new0) => { Text = $"CurrentForm: {new0.FormName}"; }
            ;
    }
}