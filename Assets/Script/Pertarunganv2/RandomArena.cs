using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArena : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject A1, A2, A3, A4, A5, A6, A7;
    int AngkaAcak;
    void Start()
    {
        AngkaAcak = Random.Range(1, 8);
        switch (AngkaAcak)
        {
            case 1:
                A1.SetActive(true);
                break;
            case 2:
                A2.SetActive(true);
                break;
            case 3:
                A3.SetActive(true);
                break;
            case 4:
                A4.SetActive(true);
                break;
            case 5:
                A5.SetActive(true);
                break;
            case 6:
                A6.SetActive(true);
                break;
            case 7:
                A7.SetActive(true);
                break;

            default:
                A1.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
