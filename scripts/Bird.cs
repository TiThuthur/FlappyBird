using Godot;
using System;

public partial class Bird : CharacterBody2D
{
    [Export]
    public float gravity = 800f;
    [Export]
    public float flapForce = -300f;
    [Export]
    public float maxFlapTime = 0.2f;//durée maximum du saut
    Vector2 screenSize;
    private bool isFlapping = false;//état en vol
    private float flapTimeLeft = 0f;//temps de vol restant
    private Vector2 velocity = Vector2.Zero;
    
    public override void _Ready()
    {
        screenSize = GetViewportRect().Size; //récupération de la taille de l'écran
        Position = new Vector2(10, screenSize.Y/2);
    }
    public override void _PhysicsProcess(double delta)
    {
        velocity.Y = gravity * (float)delta; //affectation de la gravitée

        if (Input.IsActionJustPressed("fly"))
        {
            isFlapping = true;//on passe en vol
            flapTimeLeft = maxFlapTime;//on attribut au temps restant la valeur maximum de vol possible
        }
        
        if (Input.IsActionPressed("fly") && isFlapping)
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Fly");
            velocity.Y = flapForce;//saut / vol
            flapTimeLeft -= (float)delta;//réduction du temps
            if (flapTimeLeft <= 0f)
            {
                isFlapping = false;//temps dépassé on arrêt le vol
            }
        }
        
        Velocity = velocity;
        MoveAndSlide();
    }
    
}
