using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelConfig :  MonoBehaviour, ILevelConfiguration
{
    #region ILevelConfiguration

    public Vector2 PlayerStartPosition => _playerPlaceholder.transform.position;
    public Vector2 BallStartPosition => _ballPlaceholder.transform.position;

    public IEnumerable<Vector3> BlocksPlaceholders => _blocks
        .Where(child => child.name.Contains("BlockPlaceholder"))
        .Select(child => child.transform.position);

    #endregion

    [SerializeField]
    private Transform _playerPlaceholder;
    [SerializeField]
    private Transform _ballPlaceholder;

    private Transform[] _blocks => this.GetComponentsInChildren<Transform>(true);
}
