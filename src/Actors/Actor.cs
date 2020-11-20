using Godot;
using System;

public class Actor : KinematicBody2D
{
    public Vector2 floorNormal = Vector2.Up;
    [Export]
    public float gravity = 2000.0f;
    [Export]
    public Vector2 speed = new Vector2(300.0f, 1000.0f);
    public Vector2 velocity = Vector2.Zero;

    public virtual void Die()
    {
        QueueFree();
    }

}
