using Godot;
using System;

public class Player : Actor
{

    [Export]
    private float StompImpulse = 1000.0f;


    public void OnEnemyDetectorAreaEntered(Area2D area)
    {
        this.Velocity = CalculateStompVelocity(this.Velocity, StompImpulse);
    }

    public void OnEnemyDetectorBodyEntered(PhysicsBody2D body)
    {
        Die();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        bool isJumpInterrupted = Input.IsActionJustReleased("jump") && this.Velocity.y < 0.0;
        Vector2 direction = getDirection();

        this.Velocity = CalculateMoveVelocity(this.Velocity, this.Speed, direction, isJumpInterrupted);        
        this.Velocity = MoveAndSlide(this.Velocity, this.FloorNormal);
    }

    public Vector2 getDirection()
    {
        float xDirection = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        float yDirection = Input.GetActionStrength("jump") != 0 && IsOnFloor() ? -1.0f : 1.0f;
        Vector2 direction = new Vector2(xDirection, yDirection);

        return direction;
    }

    public Vector2 CalculateMoveVelocity(Vector2 linearVelocity, 
    Vector2 speed, Vector2 direction, bool isJumpInterrupted)
    {
        Vector2 velocity = linearVelocity;
        velocity.x = speed.x * direction.x;
        velocity.y += this.Gravity * GetPhysicsProcessDeltaTime();

        if (direction.y == -1.0f)
        {
            velocity.y = speed.y * direction.y;
        }

        if (isJumpInterrupted)
        {
            velocity.y = 0.0f;
        }
        
        return velocity;
    }

    public Vector2 CalculateStompVelocity(Vector2 velocityIn, float impulse)
    {
        Vector2 velocity = velocityIn;
        velocity.y = -impulse;
        return velocity;
    }

    public override void Die()
    {
        //PlayerData.deaths += 1
        QueueFree();
    }

    public double getStompImpulse()
    {
        return StompImpulse;
    }

    public void setStompImpulse(float impulse)
    {
        StompImpulse = impulse;
    }
}
