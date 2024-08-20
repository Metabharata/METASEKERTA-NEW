using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckAuthController : MonoBehaviour
{
    string tokenUser;
    int idUser;
    string tokenRemovel = "";
    // Start is called before the first frame update
    void Start()
    {
        tokenUser = PlayerPrefs.GetString("token");
        idUser = PlayerPrefs.GetInt("id");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mulai()
    {
        if (tokenUser == "")
        {
            SceneManager.LoadScene("Login");
        }else{
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Logout()
    {

        PlayerPrefs.SetString("token", tokenRemovel);
        PlayerPrefs.SetInt("id", 0);
        SceneManager.LoadScene("AwalMulai");
    }
}
