using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePanelView : MonoBehaviour
{
    public void SetTime (TimeSpan time)
    {
        _timerText.text = $"{time.Minutes} мин. {time.Seconds} сек.";
    }

    [SerializeField]
    private Text _timerText;
}
