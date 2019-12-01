using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : IBallController
{
    #region IBallController

    public event EventHandler LoseBall;

    public void Stop()
    {
        _ballView.Rigidbody.Sleep();
    }

    public void GoToStart(Vector2 startMoveDirection)
    {
        _ballView.Rigidbody.WakeUp();
        _ballView.Rigidbody.position = StartPosition;
        _ballView.Rigidbody.AddForce(startMoveDirection, ForceMode2D.Impulse);
    }

    #endregion

    #region IReleasable

    public void Release()
    {
        GameObject.Destroy(_ballView);
    }

    #endregion

    public BallController(string prefabName, ILevelRoot gameplayCanvas, Vector2 startPosition)
    {
        _ballView = GameObject.Instantiate(Resources.Load<BallView>(prefabName), gameplayCanvas.Transform, true);
        StartPosition = startPosition;

        _ballView.Lose += OnLose;
    }

    private void OnLose(object sender, EventArgs eventArgs)
    {
        LoseBall?.Invoke(this, eventArgs);
    }

    private BallView _ballView;
    private readonly Vector2 StartPosition;
}
