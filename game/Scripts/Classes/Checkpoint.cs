using Godot;
using System;
public partial class Checkpoint:Node2D
{
    public void Respawn(Node2D body)
    {
        Player player = body as Player;
        player.respawnPosition = player.Position;
        GD.Print("Respawned");
    }
}