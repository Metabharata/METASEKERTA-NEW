using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangCheck : MonoBehaviour
{
    string langActive;
    string LangIndo = "Indonesia";
    void Start()
    {
        langActive = PlayerPrefs.GetString("language");
        if (langActive == "")
        {
            PlayerPrefs.SetString("language", LangIndo);
        }
        else if (langActive == null)
        {
            PlayerPrefs.SetString("language", LangIndo);
        }
        else
        {
            langActive = PlayerPrefs.GetString("language");
        }
        Debug.Log(langActive);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
