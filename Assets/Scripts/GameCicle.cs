using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCicle : MonoBehaviour, IGameCicle
{
    #region IGameCicle

    public bool Pause { get; set; }

    public event EventHandler<float> Tick;

    #endregion

    #region IReleasable

    public void Release()
    {
        Tick = null;
        Destroy(this);
    }

    #endregion

    #region MonoBehaviour

    private void FixedUpdate ()
    {
        if (!Pause)
        {
            Tick?.Invoke(this, Time.fixedDeltaTime);
        }
    }

    #endregion
}
