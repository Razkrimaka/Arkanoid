using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    #region MonoBehaviour

    private void Awake()
    {
        var gameplay = new Gameplay();
        gameplay.CreateLevel("Level00");
    }

    #endregion
}
