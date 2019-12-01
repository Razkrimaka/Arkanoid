using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : IUIManager
{
    #region IUIManager

    public void AddWindow(WindowID id, IWindowController controller)
    {
        _existingWindows.Add(id, controller);
    }

    public IWindowController Show( WindowID id, params object[]  args)
    {
        var result = default(IWindowController);
        if (_existingWindows.TryGetValue(id, out result))
        {
            result.Show(args);
        }

        return result;
    }

    #endregion

    private Dictionary<WindowID, IWindowController> _existingWindows = new Dictionary<WindowID, IWindowController>();
}
