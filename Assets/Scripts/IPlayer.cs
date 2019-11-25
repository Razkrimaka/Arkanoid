using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer : IReleasable
{
    void Move(float value);
    void SetInitializePosition(Vector2 position);
}
