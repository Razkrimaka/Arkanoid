using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : IScoreController
{
    #region IScoreController

    public void IncrementPoint()
    {
        Score += _currentSequenceState;
        _currentSequenceState++;
    }

    public void ResetScoreSequence()
    {
        _currentSequenceState = DefaultSequenceState;
    }

    public void GoToStart()
    {
        _currentSequenceState = DefaultSequenceState;
        Score = 0;
    }

    #endregion

    public ScoreController (ILevelRoot levelRoot)
    {
        var template = Resources.Load<ScoreView>("Prefabs/ScoreView");
        View = GameObject.Instantiate(template, levelRoot.Transform);
    }

    private int _currentSequenceState;

    private int Score
    {
        get => _score;
        set
        {
            View.SetScore(value);
            _score = value;
        }
    }

    private int _score;
    private readonly IScoreView View;

    private const int DefaultSequenceState = 1;
}
