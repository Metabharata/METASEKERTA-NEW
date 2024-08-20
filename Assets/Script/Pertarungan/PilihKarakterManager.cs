using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilihKarakterManager : MonoBehaviour
{
    public GameObject BabSatuLock, BabSatuUnlock;
    int BabSatu;
    // Start is called before the first frame update
    void Start()
    {
        BabSatu = PlayerPrefs.GetInt("BabSatuSelesai");
        Debug.Log(BabSatu);
        if (BabSatu == 1)
        {
            BabSatuLock.SetActive(false);
            BabSatuUnlock.SetActive(true);
        }
        else
        {
            BabSatuLock.SetActive(true);
            BabSatuUnlock.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
