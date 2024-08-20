using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ManaStart
{
    public ManaScript manaScript;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            this.currentVal = value;
            manaScript.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }
        set
        {
            this.maxVal = value;
            manaScript.MaxVal = value;
        }
    }
    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
