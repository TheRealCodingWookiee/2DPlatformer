using Godot;
using System;

public class PlayerData : Node
{
    private int _score;
    private int _deaths;

    public int Score
    {
        get {return _score;}
        set {_score = value;}
    }

    public int Deaths 
    {
        get {return _deaths;}
        set {_deaths = value;}
    }   
}
