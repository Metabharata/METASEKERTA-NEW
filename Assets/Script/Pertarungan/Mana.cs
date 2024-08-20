using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float mana;
    public float maxMana;

    void Awake()
    {
        mana = maxMana;
    }
}
