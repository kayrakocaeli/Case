using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action SetDatas;

    public static void StartToSetData()
    {
        if (SetDatas != null) 
            SetDatas();
    }
}
