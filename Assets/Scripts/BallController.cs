using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : IBallController
{
    #region IBallController

    public void Move(Vector2 position)
    {
        _ballView.transform.localPosition = position;
    }

    public void GoToStart()
    {
        _ballView.transform.localPosition = StartPosition;
    }

    #endregion

    #region IReleasable

    public void Release()
    {
        GameObject.Destroy(_ballView);
    }

    #endregion

    public BallController(string prefabName, IGameplayCanvas gameplayCanvas, Vector2 startPosition)
    {
        _ballView = GameObject.Instantiate(Resources.Load<BallView>(prefabName), gameplayCanvas.CanvasTransform, true);
        StartPosition = startPosition;
    }


    private BallView _ballView;
    private readonly Vector2 StartPosition;
}
