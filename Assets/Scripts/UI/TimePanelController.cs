using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePanelController : ITimePanelController
{
    #region ITimePanelController

    public void SetTime(TimeSpan timeSpan)
    {
        _view.SetTime(timeSpan);
    }

    #endregion

    public TimePanelController(ILevelRoot levelRoot)
    {
        var template = Resources.Load<TimePanelView>("Prefabs/TimePanelView");
        _view = GameObject.Instantiate(template, levelRoot.Transform);
    }


    private TimePanelView _view;
}
