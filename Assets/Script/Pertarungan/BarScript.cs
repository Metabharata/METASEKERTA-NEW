using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private Image content;

    public float MaxVal { get; set; }
    public float Value
    {
        set
        {
            fillAmount = Map(value, 1, MaxVal, 0, 1);

        }
    }
    void Start()
    {

    }

    void Update()
    {
        HandleBar();
    }
    void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
            // Debug.Log("Berhasil");
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
