using Godot;
using System;

public class Enemy : Actor
{
    private int score;
    private Global global;
    public override void _Ready()
    {
        SetPhysicsProcess(false);
        global = GetNode<Global>("/root/Global");
        Vector2 enemyVelocity = new Vector2(-this.speed.x, 0.0f);
        this.velocity = enemyVelocity;
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        this.velocity.y += this.gravity * delta;

        if (IsOnWall())
        {
            this.velocity.x *= -1;
        }

        this.velocity.y = MoveAndSlide(this.velocity, this.floorNormal).y;
    }

    public void _on_StompDetector_body_entered(PhysicsBody2D body)
    {
        Area2D stompDetector = GetNode<Area2D>("StompDetector");
        bool isBodyEntered = body.GlobalPosition.y < stompDetector.GlobalPosition.y;
        if (isBodyEntered)
        {
            CollisionShape2D enemyCollision = GetNode<CollisionShape2D>("CollisionShape2D"); 
            enemyCollision.SetDeferred("disabled", false);
            Die();
        } 
        else
            return;            
    }

    public override void Die()
    {
        global.Score += 10;
        base.Die();
    }
}
