using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelConfiguration
{
    Vector2 PlayerStartPosition { get; }
    Vector2 BallStartPosition { get; }

    IEnumerable<Vector3> BlocksPlaceholders { get; }
    IEnumerable<(Vector3 Placeholder, WallType[] ApprovedWalls)> Walls { get; }

    Vector3 GameOverPlaceholder { get; }

    float BonusTime { get; }
    float StartTime { get; }
}
