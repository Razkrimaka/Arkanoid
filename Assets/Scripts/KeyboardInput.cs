using System;
using UnityEngine;

public class KeyboardInput :  IInputController
{
    #region IInputController

    public event EventHandler<float> MoveLeft;
    public event EventHandler<float> MoveRight;

    #endregion

    #region IReleasable

    public void Release()
    {
        SetListeners(false);
    }

    #endregion

    public KeyboardInput(IGameCicle gameCicle)
    {
        GameCicle = gameCicle;
        SetListeners(true);
    }

    private void OnTick(object sender, float duration)
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight?.Invoke(this, duration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft?.Invoke(this, duration);
        }
    }

    private void SetListeners(bool listeners)
    {
        if (listeners)
        {
            GameCicle.Tick += OnTick;
        }
        else
        {
            GameCicle.Tick -= OnTick;
        }
    }

    private readonly IGameCicle GameCicle;
}
