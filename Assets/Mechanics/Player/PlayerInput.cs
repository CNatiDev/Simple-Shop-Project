using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public Action OnRun = delegate { };
    private bool Run = false;

    void Update()
    {
        if (Run)
            OnRun();
    }
}
