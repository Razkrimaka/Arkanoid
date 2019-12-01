using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogView : BaseWindowView
{
    [SerializeField]
    private ButtonWithText _buttonTemplate;
    [SerializeField]
    private Text _windowBody;
    [SerializeField]
    private Transform _buttonsContainer;

    public ButtonWithText ButtonTemplate => _buttonTemplate;
    public Transform ButtonsContainer => _buttonsContainer;

    public void SetWindowBodyText (string text)
    {
        _windowBody.text = text;
    }
}
