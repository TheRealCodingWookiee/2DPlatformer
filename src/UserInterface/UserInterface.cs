using Godot;
using System;

public class UserInterface : Control
{

    private Global global;
    private ColorRect _pauseOverlay;
    private Label _score; 
    private Label _death;
    private SceneTree _sceneTree;
    private bool _paused = false;

    public bool Paused
    {
        get {return _paused;}
        set
        {
            _paused = value;
            _sceneTree.Paused = value;
            _pauseOverlay.Visible = value;
        }
    }

    public override void _Ready()
    {
        global = GetNode<Global>("/root/Global");
        _pauseOverlay = GetNode<ColorRect>("PauseOverlay");
        _sceneTree = GetTree();
        _death = GetNode<Label>("Label");
        _score = GetNode<Label>("PauseOverlay/Title");

        global.Connect("ScoreUpdate", this, nameof(UpdateInterface));
        global.Connect("PlayerDied", this, nameof(UpdatePlayerDied));
        UpdateInterface();
    }
    
    public override void _UnhandledInput(InputEvent @event)
    {
        bool isPressed = @event.IsActionPressed("pause");
        if (isPressed)
        {
            Paused = !_paused;
            _sceneTree.SetInputAsHandled();
        }
    }

    public void UpdatePlayerDied()
    {
        Paused = true;
        _death.Text = "You Died!";
    }

    public void UpdateInterface()
    {
        _score.Text = $"Score: {global.Score}";
    }

}
