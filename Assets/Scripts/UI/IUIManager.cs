using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager 
{
    void AddWindow(WindowID id, IWindowController controller);
    IWindowController Show(WindowID id, params object[] args);
}
