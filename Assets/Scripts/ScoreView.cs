using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour, IScoreView
{
    #region IScoreView

    public void SetScore(int value)
    {
        _scoreText.text = value.ToString();
    }

    #endregion

    [SerializeField]
    private Text _scoreText;
}
