using Godot;

[Tool]
public class Portal : Area2D
{
    [Export]
    private PackedScene nextScene;
    private AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }
    public void OnPortal2DBodyEntered(PhysicsBody2D body)
    {
        Teleport();
    }

    public override string _GetConfigurationWarning()
    {
        string warning = nextScene == null ? "Next Level Can't Be Empty" : ""; 
        return warning;
    }

    public async void Teleport()
    {
        animationPlayer.Play("fade_in");
        await ToSignal(animationPlayer, "animation_finished");
        GetTree().ChangeSceneTo(nextScene);
    }
}
