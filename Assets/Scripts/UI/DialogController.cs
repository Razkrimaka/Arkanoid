using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : BaseWindowController<DialogView>
{

    #region IWindowController

    public override event EventHandler<ButtonCommands> WindowClosed;

    #endregion

    #region BaseWindowControler 

    protected override string WindowPrefabPath => "Prefabs/DialogView";

    public override void Show(params object[] args)
    {
        View = CreateView();

        var windowBody = args[0] as string;
        var buttonsText = args[1] as string[];
        var buttonCommands = args[2] as ButtonCommands[];

        if (buttonsText != null &&
            buttonCommands != null &&
            !string.IsNullOrEmpty(windowBody) &&
            buttonsText.Length == buttonCommands.Length)
        {
            View.SetWindowBodyText(windowBody);
            InitButtons(buttonsText, buttonCommands);
        }
        else
        {
            Debug.LogError("Ошибка создания диалогового окна");
        }
    }


    #endregion

    public DialogController(IUIRoot levelRoot) : base(levelRoot)
    {
    }

    private void InitButtons (string[] buttonsText, ButtonCommands[] buttonCommands) 
    {
        for (var i = 0; i < buttonsText.Length; i++)
        {
            var buttonInstance = GameObject.Instantiate(View.ButtonTemplate, View.ButtonsContainer);
            buttonInstance.gameObject.SetActive(true);
            buttonInstance.Text.text = buttonsText[i];
            var buttonComand = buttonCommands[i];
            buttonInstance.Button.onClick.AddListener(() => { ButtonClickHandle(buttonComand); });
        }

        void ButtonClickHandle(ButtonCommands commandId)
        {
            WindowClosed?.Invoke(this, commandId);
            GameObject.Destroy(View);
        }
    }

    private DialogView View;
}
