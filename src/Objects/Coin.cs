using Godot;
using System;

public class Coin : Area2D
{

    private int score = 100;
    private AnimationPlayer animationPlayer;
    private Global global;

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        global = GetNode<Global>("/root/Global");
    }

    public void OnCoinBodyEntered(PhysicsBody2D body)
    {
        Picked();
    }

    private void Picked()
    {
        global.Score += 100;
        animationPlayer.Play("fade_out");
    }
}
