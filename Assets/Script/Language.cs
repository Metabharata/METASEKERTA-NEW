using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public GameObject EnglishAc, JawaAc, IndoAc;
    public GameObject English, Jawa, Indo;
    public GameObject ObjEnglish, ObjJawa, ObjIndo;

    string LangIng = "English";
    string LangJawa = "Jawa";
    string LangIndo = "Indonesia";
    string langActive;

    void Start()
    {
        langActive = PlayerPrefs.GetString("language");
        Debug.Log(langActive);
        if (langActive == "Indonesia")
        {
            Lang_Indonesia();
        }
        else if (langActive == "Jawa")
        {
            Lang_Jawa();
        }
        else
        {
            Lang_English();
        }
    }

    public void Lang_English()
    {
        PlayerPrefs.SetString("language", LangIng);
        EnglishAc.SetActive(true);
        JawaAc.SetActive(false); // Disable other language GameObjects
        IndoAc.SetActive(false);
        Jawa.SetActive(true);
        Indo.SetActive(true);

        ObjIndo.SetActive(false);
        ObjJawa.SetActive(false);
        ObjEnglish.SetActive(true);
    }

    public void Lang_Jawa()
    {
        PlayerPrefs.SetString("language", LangJawa);
        EnglishAc.SetActive(false);
        JawaAc.SetActive(true);
        IndoAc.SetActive(false);
        English.SetActive(true);
        Indo.SetActive(true);

        ObjIndo.SetActive(false);
        ObjJawa.SetActive(true);
        ObjEnglish.SetActive(false);
    }

    public void Lang_Indonesia()
    {
        PlayerPrefs.SetString("language", LangIndo);
        EnglishAc.SetActive(false);
        JawaAc.SetActive(false);
        IndoAc.SetActive(true);
        Jawa.SetActive(true);
        English.SetActive(true);

        ObjIndo.SetActive(true);
        ObjJawa.SetActive(false);
        ObjEnglish.SetActive(false);
    }
}
