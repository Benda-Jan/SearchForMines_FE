using System;

namespace BattleGameWeb.Dtos;

public class GameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string State { get; set; } = String.Empty;
    public int MinesCount { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeFinished { get; set; }
    public List<GameFieldDto>? GameFields { get; set; }
}

