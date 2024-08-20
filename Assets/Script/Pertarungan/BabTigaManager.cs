using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabTigaManager : MonoBehaviour
{
    string ManajemenBab = "BabTiga";
    private bool babSatuSelesai = false;
    private MenuManager menuManager; // Tambahkan variabel ini

    private void Awake()
    {
        menuManager = MenuManager.Instance; // Inisialisasi instans menuManager

    }

    private void Start()
    {
        // babSatuSelesai = PlayerPrefs.GetInt("BabSatuSelesai", 0) == 1;
        int[] unlockedIndices = { 17, 18 };
        // if (babSatuSelesai)
        // {
        //     PlayerPrefs.SetInt("BabSatuSelesai", 0);
        //     int[] unlockedIndices = { 2, 14 }; // Indeks karakter yang akan dibuka
        //     // menuManager.UnlockSpecificCharacters(unlockedIndices); // Gunakan menuManager untuk membuka karakter
        // }
    }

    public void SelesaiPertarungan()
    {
        babSatuSelesai = true;
        PlayerPrefs.SetString("BabTigaSelesaiMeta", ManajemenBab);
        // menuManager.UnlockAllCharacters();
        Debug.Log("berhasil");
    }
}
