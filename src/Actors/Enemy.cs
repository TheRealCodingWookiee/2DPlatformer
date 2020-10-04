using Godot;
using System;

public class Enemy : Actor
{
    private int Score;
    public override void _Ready()
    {
        SetPhysicsProcess(false);
        Vector2 enemyVelocity = new Vector2(-this.Speed.x, 0.0f);
        GD.Print(enemyVelocity);
        this.Velocity = enemyVelocity;
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        this.Velocity.y += this.Gravity * delta;

        if (IsOnWall())
        {
            this.Velocity.x *= -1;
        }

        this.Velocity.y = MoveAndSlide(this.Velocity, this.FloorNormal).y;
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
        //PlayerData.score += score;
        base.Die();
    }
}
