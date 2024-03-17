using System;

namespace BattleGameWeb.Dtos;

/// <summary>
/// Create object for Game object
/// </summary>
public class GameInputDto
{
    /// <summary>
    /// Name of game
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Number of mines in the game
    /// </summary>
    public int MinesCount { get; set; }
}


