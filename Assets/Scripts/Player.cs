using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :  IPlayer
{
    #region IPlayer

    public void Move(float xPosition)
    {
        _playerView.transform.localPosition = new Vector3(xPosition, YPosition);
    }

    public void SetInitializePosition(Vector2 position)
    {
        _playerView.transform.localPosition = position;
    }

    #endregion

    #region IReleasable

    public void Release()
    {
        GameObject.Destroy(_playerView);
    }

    #endregion

    public Player(string prefabName, IGameplayCanvas gameplayCanvas)
    {
        _playerView = GameObject.Instantiate(Resources.Load<PlayerView>(prefabName), gameplayCanvas.CanvasTransform, true);
    }

    private PlayerView _playerView;
    private float YPosition => _playerView.transform.localPosition.y;
}
