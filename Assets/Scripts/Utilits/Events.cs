using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public delegate void OnCarButtonClickDelegate(int index);
    public static OnCarButtonClickDelegate buttonClickDelegate;

    public delegate void OnGroundChangeDelegate(int value);
    public static OnGroundChangeDelegate groundChangeDelegate;

}


