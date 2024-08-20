using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking : MonoBehaviour
{
    string langActive;
    public GameObject English, Jawa, Indo;
    public string linkIg;
    void Start()
    {
        langActive = PlayerPrefs.GetString("language");
        Debug.Log(langActive);
        if (langActive == "Indonesia")
        {
            Indo.SetActive(true);
            Jawa.SetActive(false);
            English.SetActive(false);
        }
        else if (langActive == "Jawa")
        {
            Indo.SetActive(false);
            Jawa.SetActive(true);
            English.SetActive(false);
        }
        else
        {
            Indo.SetActive(false);
            Jawa.SetActive(false);
            English.SetActive(true);
        }
    }

    public void Open()
    {
        Application.OpenURL(linkIg);
    }


}
