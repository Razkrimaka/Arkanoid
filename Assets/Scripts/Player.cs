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

    public void IncreaseWidth()
    {
        CurentWidth += WidthStep;
    }

    public void ResetWidth()
    {
        CurentWidth = DefaultWidth;
    }

    #endregion

    #region IReleasable

    public void Release()
    {
        GameObject.Destroy(_playerView);
    }

    #endregion

    public Player(string prefabName, ILevelRoot gameplayCanvas, Vector2 startPosition)
    {
        _playerView = GameObject.Instantiate(Resources.Load<PlayerView>(prefabName), gameplayCanvas.Transform, true);
        StartPosition = startPosition;
    }

    private float CurentWidth
    {
        get => _currentWidth;
        set
        {
            _currentWidth = _currentWidth < MaxWidth ? value : _currentWidth;
            _playerView.SetWidth(_currentWidth);
        }
    }

    private PlayerView _playerView;
    private float YPosition => _playerView.transform.position.y;
    private readonly Vector2 StartPosition;
    private float _currentWidth;

    private const float MaxWidth = 400f;
    private const float WidthStep = 10f;
    private const float DefaultWidth = 190f;
}
