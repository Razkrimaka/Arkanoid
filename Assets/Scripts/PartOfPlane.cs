using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOfPlane : IPartOfPlane
{
    #region IPartOfPlane

    public Vector2 Normal { get; private set; }

    public void IsEntered(Vector2 position)
    {
        
    }

    public Vector2 MiddlePoint { get; private set; }

    #endregion

    public PartOfPlane(Vector3 point1, Vector3 point2 , string id)
    {
        _point1 = point1;
        _point2 = point2;
        ID = id;
        var ax = point2.x - point1.x;
        var ay = point2.y - point1.y;

        Vector2 normalVector;

        if (ax != 0)
        {
            var by = ax > 0 ? 1 : -1;
            var bx = -(ay * by / ax);

            normalVector = new Vector2(bx, by);
        }
        else
        {
            var bx = ay < 0 ? 1 : -1;
            var by = -(ax * bx / ay);

            normalVector = new Vector2(bx, by);
        }

        Normal = normalVector;

        var xMid = ((point2.x - point1.x) / 2) + point1.x;
        var yMid = ((point2.y - point1.y) / 2) + point1.y;

        MiddlePoint = new Vector2(xMid, yMid);


        //Debug.LogError($"Сегмент: {ID}; Нормаль: {Normal}");
    }

    private Vector2 _point1;
    private Vector2 _point2;

    private string ID;
}
