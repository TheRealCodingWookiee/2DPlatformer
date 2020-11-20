using Godot;
using System;

public class Global : Node
{
    private int _score;
    private int _deaths;

    [Signal]
    public delegate void ScoreUpdate();
    [Signal]
    public delegate void PlayerDied();

    public int Score
    {
        get {return _score;}
        set 
        {
            _score = value;
            EmitSignal(nameof(ScoreUpdate));        
        }
    }

    public int Deaths 
    {
        get {return _deaths;}
        set 
        {
            _deaths = value;
            EmitSignal(nameof(PlayerDied));
            
        }
    }   
}
