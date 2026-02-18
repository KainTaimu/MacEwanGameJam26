using Godot;

namespace MacEwanGameJam26.Players;

public partial class PlayerShapeShiftingController : Node
{
    [Signal]
    public delegate void OnFormChangedEventHandler(PlayerShiftForm old, PlayerShiftForm new0);

    [Export]
    public PlayerShiftForm CurrentForm
    {
        get;
        set
        {
            if (value == field)
                return;

            var old = field;
            field = value;
            EmitSignalOnFormChanged(old, value);
            CustomLogger.LogDebug($"Shifted to {value.FormName}");
        }
    }

    public override void _Ready()
    {
        if (CurrentForm is not null)
            EmitSignalOnFormChanged(CurrentForm, CurrentForm);

        foreach (var node in GetChildren())
        {
            if (node is not PlayerShiftForm form)
                continue;
            CustomLogger.LogDebug($"Registering form {form.GetType().Name}");
        }
    }
}