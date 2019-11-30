using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallController : IReleasable
{
    void GoToStart(Vector2 startMoveDirection);
}
