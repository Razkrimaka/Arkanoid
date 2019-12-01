using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreController
{
    void IncrementPoint();
    void ResetScoreSequence();

    void GoToStart();
}
