using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    #region MonoBehaviour

    private void Awake()
    {
        var uiRootTemplate = Resources.Load<UIRoot>("Prefabs/UIRoot");
        _uIRoot = Instantiate(uiRootTemplate);
        _uiManager = new UIManager();
        InitializeUIManager();
        var gameplay = new Gameplay(_uiManager);
        gameplay.CreateLevel("Level00");
    }

    #endregion

    private void InitializeUIManager ()
    {
        _uiManager.AddWindow(WindowID.Dialog, new DialogController(_uIRoot));
    }

    private IUIRoot _uIRoot;
    private IUIManager _uiManager;
}
