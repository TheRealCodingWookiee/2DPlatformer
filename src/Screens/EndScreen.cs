using Godot;
using System;

public class EndScreen : Control
{

    private Label _label;
    private Global _global;

    public override void _Ready()
    {   
        _global = GetNode<Global>("/root/Global");
        _label = GetNode<Label>("Label");
        _label.Text = _label.Text;
        var s = "d";
    }


}
