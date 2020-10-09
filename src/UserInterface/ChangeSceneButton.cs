using Godot;
using System;

[Tool]
public class ChangeSceneButton : Button
{
    [Export(PropertyHint.File)]
    private string nextScenePath;

    public void OnButtonUp()
    {
        GetTree().ChangeScene(nextScenePath);
    }

    public override string _GetConfigurationWarning()
    {
        string warning = nextScenePath != "" ? "Path darf net fehlen" : "";
        return warning;

    }
}
