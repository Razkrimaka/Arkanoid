 using UnityEngine;

public class Player :  IPlayer
{
    #region IPlayer

    public void Move(float xPosition)
    {
        _playerView.transform.position = new Vector3(xPosition, YPosition);
    }

    public void GoToStart()
    {
        _playerView.transform.position = StartPosition;
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
    private float YPosition => _playerView.transform.position.y;
    private readonly Vector2 StartPosition;
}
