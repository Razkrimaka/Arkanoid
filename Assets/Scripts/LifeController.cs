using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : ILifeController
{
    #region ILifeController

    public event EventHandler GameOver;

    public void DecreaseHP()
    {
        CurrentHP--;
    }

    public void IncreaseHP()
    {
        CurrentHP++;
    }

    public void GoToStart ()
    {
        CurrentHP = DefaultHP;
    }
    #endregion

    public LifeController(ILevelRoot levelRoot)
    {
        var template = Resources.Load<LifeView>("Prefabs/LifeView");
        View = GameObject.Instantiate(template, levelRoot.Transform);
    }

    private int _currentHP;
    private int CurrentHP
    {
        get => _currentHP;
        set
        {
            _currentHP = value;
            View.SetCurrentHP(value);
            if (_currentHP<=0)
            {
                GameOver?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private readonly ILifeView View;

    private const int DefaultHP = 1;
}
