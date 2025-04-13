using Godot;
using System;

public partial class Game : Node2D
{
    [Export]
    public PackedScene solScene;
    public override void _Ready()
    {
        Node2D sol = solScene.Instantiate<Node2D>();
        AddChild(sol);
        sol.Position = new Vector2(20, 200);
    }

}
