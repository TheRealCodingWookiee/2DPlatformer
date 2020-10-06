using Godot;
using System;

public class Coin : Area2D
{

    private int score = 100;
    private AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public void OnCoinBodyEntered(PhysicsBody2D body)
    {
        Picked();
    }

    private void Picked()
    {
        //Playerdata
        animationPlayer.Play("fade_out");
    }
}
