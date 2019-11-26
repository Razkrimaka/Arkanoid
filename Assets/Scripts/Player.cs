 using UnityEngine;

public class Player :  IPlayer
{
    #region IPlayer

    public void Move(float xPosition)
    {
        _playerView.transform.localPosition = new Vector3(xPosition, YPosition);
    }

    public void GoToStart()
    {
        _playerView.transform.localPosition = StartPosition;
    }

    #endregion

    #region IReleasable

    public void Release()
    {
        GameObject.Destroy(_playerView);
    }

    #endregion

    public Player(string prefabName, IGameplayCanvas gameplayCanvas, Vector2 startPosition)
    {
        _playerView = GameObject.Instantiate(Resources.Load<PlayerView>(prefabName), gameplayCanvas.CanvasTransform, true);
        StartPosition = startPosition;
    }

    private PlayerView _playerView;
    private float YPosition => _playerView.transform.localPosition.y;
    private readonly Vector2 StartPosition;
}
