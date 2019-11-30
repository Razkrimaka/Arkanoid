using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "WallPack", menuName = "Configs/WallPack")]
public class WallPack : ScriptableObject, IWallPack
{
    #region IWallPack

    public Wall GetWall(WallType type)
    {
        return _config.Where(wall => wall.WallType == type).Select(wall => wall.Item).FirstOrDefault();
    }

    #endregion

    [SerializeField]
    private WallItem[] _config;


    [Serializable]
    private class WallItem
    {
        [SerializeField]
        string _name;
        [SerializeField]
        WallType _wallType;
        [SerializeField]
        Wall _item;

        public WallType WallType => _wallType;
        public Wall Item => _item;
    }
}
