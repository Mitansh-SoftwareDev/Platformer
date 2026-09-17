using Godot;
using System;

public partial class KillZone : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public void kill(Node2D player)
	{
		Player newPlayer = player as Player;
		newPlayer.respawn();
		
	}
	
	public override void _Process(double delta)
	{
	}
}
