using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig :  MonoBehaviour, ILevelConfiguration
{
    #region ILevelConfiguration

    public Vector2 PlayerStartPosition => _playerPlaceholder.transform.position;

    #endregion

    [SerializeField]
    private Transform _playerPlaceholder;
}
