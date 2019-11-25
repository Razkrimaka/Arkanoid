using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCanvas : MonoBehaviour, IGameplayCanvas
{
    #region IGameplayCanvas

    public Transform CanvasTransform => transform;

    #endregion

}
