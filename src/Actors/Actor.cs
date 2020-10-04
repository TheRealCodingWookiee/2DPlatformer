using Godot;
using System;

public class Actor : KinematicBody2D
{
    public Vector2 FloorNormal = Vector2.Up;
    [Export]
    public float Gravity = 2000.0f;
    [Export]
    public Vector2 Speed = new Vector2(300.0f, 1000.0f);
    public Vector2 Velocity = Vector2.Zero;

    public virtual void Die()
    {
        QueueFree();
    }

}
