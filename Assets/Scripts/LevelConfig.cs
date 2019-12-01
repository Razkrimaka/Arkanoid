using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LevelConfig : MonoBehaviour, ILevelConfiguration
{
    #region ILevelConfiguration

    public Vector2 PlayerStartPosition => _playerPlaceholder.transform.position;
    public Vector2 BallStartPosition => _ballPlaceholder.transform.position;

    public IEnumerable<Vector3> BlocksPlaceholders => _blocks
        .Where(child => child.name.Contains("BlockPlaceholder"))
        .Select(child => child.transform.position);

    public IEnumerable<(Vector3 Placeholder, WallType[] ApprovedWalls)> Walls => _walls.Select(wall => (wall.Placeholder, wall.ApprovedWalls));

    public Vector3 LevelEndPlaceholder => _gameOverPlaceholder.transform.position;

    public float BonusTime => _bonusTime;
    public float StartTime => _startTime;

    #endregion

    [SerializeField]
    private Transform _playerPlaceholder;
    [SerializeField]
    private Transform _ballPlaceholder;
    [SerializeField]
    private WallConfig[] _walls;
    [SerializeField]
    private Transform _gameOverPlaceholder;
    [SerializeField]
    private float _bonusTime;
    [SerializeField]
    private float _startTime;

    private Transform[] _blocks => this.GetComponentsInChildren<Transform>(true);

    [Serializable]
    private class WallConfig
    {
        [SerializeField]
        Transform _placeholder;
        [SerializeField]
        WallType[] _approvedWalls;

        public Vector3 Placeholder => _placeholder.position;
        public WallType[] ApprovedWalls => _approvedWalls;
    }
}
