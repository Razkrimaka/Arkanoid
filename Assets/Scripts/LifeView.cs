using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeView : MonoBehaviour, ILifeView
{
    #region ILifeView

    public void SetCurrentHP(int currentHP)
    {
        for (var i = 0; i < _lifeIcons.Length; i++)
        {
            _lifeIcons[i].gameObject.SetActive(i <= currentHP);
        }
    }

    #endregion

    private void Awake()
    {
        _lifeIcons = GetComponentsInChildren<Image>();
    }

    private Image[] _lifeIcons;
}
