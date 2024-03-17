using System;

namespace BattleGameWeb.Dtos;

public class GameFieldDto
	{
    public int Id { get; set; }
    public GameDto? Game { get; set; }
    public int posX { get; set; }
    public int posY { get; set; }
    public bool Revield { get; set; }
    public bool HasMine { get; set; }
    public int MinesAround { get; set; }
}

