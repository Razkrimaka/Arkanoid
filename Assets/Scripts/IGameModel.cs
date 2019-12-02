using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel : IReleasable
{
    event EventHandler<TimeSpan> TimeChanged;
    event EventHandler<GameOverReasons> GameOver;

    void GoToStart();
    void NextLevel();
}
