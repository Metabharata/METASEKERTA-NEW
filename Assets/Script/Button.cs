using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Button : MonoBehaviour
{

    string tokenUser;

    void Start()
    {
        tokenUser = PlayerPrefs.GetString("token");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Selanjutnya()
    {
        if(tokenUser =="")
        {
            SceneManager.LoadScene("Login");
        }
        else
        {
            SceneManager.LoadScene("Loading");
        }

    }
    public void Daftar()
    {
        SceneManager.LoadScene("Register");
    }
    public void ModeCerita()
    {
        SceneManager.LoadScene("ModeCerita");
    }
    public void Exit()
    {
        PlayerPrefs.SetString("token", "");
        SceneManager.LoadScene("Loadingkeluar");
    }

    public void Login()
    {
        SceneManager.LoadScene("Loading");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Almanak()
    {
        SceneManager.LoadScene("Almanak");
    }

    public void Pengaturan()
    {
        SceneManager.LoadScene("Pengaturan");
    }
    public void Tentang()
    {
        SceneManager.LoadScene("Tentang");
    }

    //Tarung Bebas
    // public void Next()
    // {
    //     SceneManager.LoadScene("Arena");
    // }


    //MODE CERITA BAB 1-7
    public void BattleBab1()
    {
        SceneManager.LoadScene("TarungBabSatu");
    }
    public void BattleBab2()
    {
        SceneManager.LoadScene("TarungBabDua");
    }
    public void BattleBab3()
    {
        SceneManager.LoadScene("TarungBabTiga");
    }
    public void BattleBab4()
    {
        SceneManager.LoadScene("TarungBabEmpat");
    }
    public void BattleBab5()
    {
        SceneManager.LoadScene("TarungBabLima");
    }
    public void BattleBab6()
    {
        SceneManager.LoadScene("TarungBabEnam");
    }
    public void BattleBab7()
    {
        SceneManager.LoadScene("TarungBabTujuh");
    }

    //PEMBATAS
    public void TarungBebas()
    {
        SceneManager.LoadScene("PilihKarakter");
    }

    //BUTTON MODE CERITA
    public void Lvl1()
    {
        SceneManager.LoadScene("BabSatu");
    }
    public void Lvl2()
    {
        SceneManager.LoadScene("BabDua");
    }
    public void Lvl3()
    {
        SceneManager.LoadScene("BabTiga");
    }
    public void Lvl4()
    {
        SceneManager.LoadScene("BabEmpat");
    }
    public void Lvl5()
    {
        SceneManager.LoadScene("BabLima");
    }
    public void Lvl6()
    {
        SceneManager.LoadScene("BabEnam");
    }
    public void Lvl7()
    {
        SceneManager.LoadScene("BabTujuh");
    }
    public void KembaliModeCerita()
    {
        SceneManager.LoadScene("ModeCerita");
    }
    //BABSATU
    public void BerikutnyaBab1()
    {
        SceneManager.LoadScene("BabSatua");
    }
    public void SebelumnyaBab1()
    {
        SceneManager.LoadScene("BabSatu");
    }

    //BAB DUAA
    public void BerikutnyaBab2()
    {
        SceneManager.LoadScene("BabDuaa");
    }
    public void SebelumnyaBab2()
    {
        SceneManager.LoadScene("BabDua");
    }

    //Bab Tiga
    public void BerikutnyaBab3()
    {
        SceneManager.LoadScene("BabTigaa");
    }
    public void SebelumnyaBab3()
    {
        SceneManager.LoadScene("BabTiga");
    }

    //BAB EMPAT
    public void BerikutnyaBab4()
    {
        SceneManager.LoadScene("BabEmpata");
    }
    public void SebelumnyaBab4()
    {
        SceneManager.LoadScene("BabEmpat");
    }

    //BAB LIMA
    public void BerikutnyaBab5()
    {
        SceneManager.LoadScene("BabLimaa");
    }
    public void SebelumnyaBab5()
    {
        SceneManager.LoadScene("BabLima");
    }
    public void BerikutnyaBab6()
    {
        SceneManager.LoadScene("BabEnama");
    }
    public void SebelumnyaBab6()
    {
        SceneManager.LoadScene("BabEnam");
    }
    public void BerikutnyaBab7()
    {
        SceneManager.LoadScene("BabTujuha");
    }
    public void BerikutnyaBab7b()
    {
        SceneManager.LoadScene("BabTujuhb");
    }
    public void SebelumnyaBab7()
    {
        SceneManager.LoadScene("BabTujuh");
    }
    public void SebelumnyaBab7b()
    {
        SceneManager.LoadScene("BabTujuha");
    }

    //Arena
    public void KembaliPilihKarakter()
    {
        SceneManager.LoadScene("PilihKarakter");
    }
    //BUTTON ALMANAK
    public void Arjuna()
    {
        SceneManager.LoadScene("Arjuna");
    }

    public void Bima()
    {
        SceneManager.LoadScene("Bima");
    }

    public void Yudistira()
    {
        SceneManager.LoadScene("Yudistira");
    }

    public void Nakula()
    {
        SceneManager.LoadScene("Nakula");
    }

    public void Sadewa()
    {
        SceneManager.LoadScene("Sadewa");
    }

    public void Duryudana()
    {
        SceneManager.LoadScene("Duryudana");
    }

    public void Salya()
    {
        SceneManager.LoadScene("Salya");
    }

    public void Drupadi()
    {
        SceneManager.LoadScene("Drupadi");
    }

    public void Dursasana()
    {
        SceneManager.LoadScene("Dursasana");
    }

    public void Hanoman()
    {
        SceneManager.LoadScene("Anoman");
    }

    public void Abimanyu()
    {
        SceneManager.LoadScene("Abimanyu");
    }

    public void Kresna()
    {
        SceneManager.LoadScene("Kresna");
    }

    public void Batara()
    {
        SceneManager.LoadScene("Barata");
    }

    public void Sengkuni()
    {
        SceneManager.LoadScene("Sangkuni");
    }
    public void Citrasena()
    {
        SceneManager.LoadScene("Citrasena");
    }

    public void Back()
    {
        SceneManager.LoadScene("Almanak");
    }
}
