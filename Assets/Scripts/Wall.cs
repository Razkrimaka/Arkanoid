using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IReleasable
{
    #region IReleasable

    public void Release()
    {
        Destroy(this.gameObject);
    }

    #endregion
}
