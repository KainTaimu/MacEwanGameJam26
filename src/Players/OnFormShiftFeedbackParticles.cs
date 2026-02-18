using Godot;

namespace MacEwanGameJam26.Players;

public partial class OnFormShiftFeedbackParticles : CpuParticles2D
{
    [Export] private PlayerShapeShiftingController _shiftingController;

    public override void _Ready()
    {
        _shiftingController?.OnFormChanged += (_, _) =>
        {
            Emitting = false;
            Callable.From(() => { Emitting = true; }).CallDeferred();
        };
    }
}