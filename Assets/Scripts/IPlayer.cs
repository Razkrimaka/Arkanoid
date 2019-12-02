using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer : IReleasable
{
    void Move(float value);
    void GoToStart();
    void ResetWidth();

    void IncreaseWidth();
}
