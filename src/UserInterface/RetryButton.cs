using Godot;
using System;

public class RetryButton : Button
{

    private Global global;
    public override void _Ready()
    {
        global = GetNode<Global>("/root/Global");
    }

    public void OnRetryButtonUp()
    {
        global.Score = 0;
        GetTree().Paused = false;
        GetTree().ReloadCurrentScene();
    }
}
