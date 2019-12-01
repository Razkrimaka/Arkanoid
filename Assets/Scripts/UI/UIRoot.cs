using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour, IUIRoot
{
    #region IUIRoot

    public Transform Transform => _uiRoot;

    #endregion

    [SerializeField]
    private Transform _uiRoot;
}
