using Godot;
using System;

public class QuitButton : Button
{
    public void OnQuitButtonUp()
    {
        GetTree().Quit();
    }
}
