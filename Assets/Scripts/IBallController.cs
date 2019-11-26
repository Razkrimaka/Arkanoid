using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallController : IReleasable
{
    void Move(Vector2 position);
    void GoToStart();
}
