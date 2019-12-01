using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoot : MonoBehaviour, ILevelRoot
{
    #region ILevelRoot

    public Transform Transform => transform;

    #endregion

}
