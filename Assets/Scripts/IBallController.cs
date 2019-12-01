using System;
using UnityEngine;

public interface IBallController : IReleasable
{
    event EventHandler LoseBall;
    event EventHandler TouchPlatform;

    void GoToStart(Vector2 startMoveDirection);
    void Stop();
}
