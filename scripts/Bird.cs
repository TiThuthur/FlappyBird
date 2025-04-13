using Godot;
using System;

public partial class Bird : CharacterBody2D
{
    [Export]
    public float gravity = 800f;
    [Export]
    public float flapForce = -300f;
    Vector2 screenSize;
    private Vector2 velocity = Vector2.Zero;
    
    public override void _Ready()
    {
        screenSize = GetViewportRect().Size; //récupération de la taille de l'écran
        Position = new Vector2(10, screenSize.Y/2);
    }
    public override void _PhysicsProcess(double delta)
    {
        velocity = Vector2.Zero;
        if (Input.IsActionPressed("fly"))
        {
            velocity = new Vector2(1, -1);
            
        }
        if (velocity.X > 0  )
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Fly");
            
        }
        velocity.Y = gravity;
        MoveAndSlide();
    }
    
}
