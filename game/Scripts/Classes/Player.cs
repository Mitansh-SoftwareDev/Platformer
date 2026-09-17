using Godot;

public partial class Player: CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -300.0f;
    public Vector2 respawnPosition = Vector2.Zero;

    public void respawn()
    {
        GD.Print("working");
        Position = respawnPosition;
    }
	
	
    public override void _PhysicsProcess(double delta)
    {	 	
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("Up") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }
        if (!IsOnFloor() && Velocity.Y >= 0)
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Fall");
        }
        else if (!IsOnFloor() && Velocity.Y < 0)
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Jump");
        }
        if (Input.IsActionJustPressed("Left") ||  Input.IsActionJustPressed("Right"))
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Run");
        }
        if (Input.IsActionPressed("Left"))
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
        }
        else if (Input.IsActionPressed("Right"))
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
			
        }
        else if (IsOnFloor())
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Idle");
        }
		
        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");
		
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}