using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : IBallController
{
    #region IBallController

    public event EventHandler LoseBall;
    public event EventHandler TouchPlatform;


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

        _ballView.Collision += OnCollision;
    }

    private void OnCollision(object sender, string tag)
    {
        switch(tag)
        {
            case "Player":
                TouchPlatform?.Invoke(this, EventArgs.Empty);
                break;
            case "Finish":
                LoseBall?.Invoke(this, EventArgs.Empty);
                break;
        }        
    }

    private BallView _ballView;
    private readonly Vector2 StartPosition;
}
