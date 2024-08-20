using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    public GameObject ObjectMenuPause, ObjectPengaturan;

    private bool isPaused = false;

    private void Update()
    {
        if (isPaused)
        {
            // Jika game dalam keadaan terpause, hentikan semua aksi yang berjalan.
            Time.timeScale = 0f;
        }
        else
        {
            // Jika game tidak dalam keadaan terpause, biarkan waktu berjalan normal.
            Time.timeScale = 1f;
        }
    }

    public void pauseMenu()
    {
        isPaused = true;
        ObjectMenuPause.SetActive(true);
    }

    public void closePause()
    {
        isPaused = false;
        ObjectMenuPause.SetActive(false);
    }

    public void MenuPengaturan()
    {
        isPaused = true;
        ObjectMenuPause.SetActive(false);
        ObjectPengaturan.SetActive(true);
    }

    public void BackPengaturan()
    {
        isPaused = true;
        ObjectMenuPause.SetActive(true);
        ObjectPengaturan.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        ObjectMenuPause.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToModeCerita()
    {
        SceneManager.LoadScene("ModeCerita");
    }
}
