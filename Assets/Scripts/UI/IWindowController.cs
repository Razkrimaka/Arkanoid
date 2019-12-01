using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindowController
{
    event EventHandler<ButtonCommands> WindowClosed;

    void Show(params object[] args);
}
