using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static Action OnHpChanged;

    public static void SendHPChanged()
    {
        if (OnHpChanged != null) OnHpChanged.Invoke();
    }
}
