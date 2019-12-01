using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWindowController<T> : IWindowController
    where T: BaseWindowView 
{
    #region IWindowController

    public virtual event EventHandler<ButtonCommands> WindowClosed;

    public abstract void Show(params object[] args);

    #endregion

    protected BaseWindowController (IUIRoot uiRoot)
    {
        UIRoot = uiRoot;
    }

    protected abstract string WindowPrefabPath { get; }

    protected T CreateView ()
    {
        var template = Resources.Load<T>(WindowPrefabPath);
        var instance = GameObject.Instantiate(template, UIRoot.Transform);
        return instance;
    }

    private readonly IUIRoot UIRoot;
}
