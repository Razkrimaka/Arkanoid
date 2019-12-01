using System;
using UnityEngine;

public interface IBallController : IReleasable
{
    event EventHandler LoseBall;

    void GoToStart(Vector2 startMoveDirection);
    void Stop();
}
