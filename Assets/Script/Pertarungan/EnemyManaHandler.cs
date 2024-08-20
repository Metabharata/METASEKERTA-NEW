using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManaHandler : MonoBehaviour
{
    public Image manaBar;
    public float maxMana = 100f;
    private float currentMana;

    private bool canUseSkill = false;

    void Start()
    {
        currentMana = 0f;
        manaBar.fillAmount = 0f;
    }

    void Update()
    {
        if (currentMana < maxMana)
        {
            currentMana = Mathf.MoveTowards(currentMana, maxMana, Time.deltaTime * 10f);
            manaBar.fillAmount = currentMana / maxMana;
        }


        if (currentMana >= maxMana)
        {
            canUseSkill = true;
        }
    }
    public float CurrentMana
    {
        get { return currentMana; }
    }
}
