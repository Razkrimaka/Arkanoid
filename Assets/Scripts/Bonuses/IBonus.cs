using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonus 
{
    event EventHandler Picked;
    event EventHandler Over;
}
