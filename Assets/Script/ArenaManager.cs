using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using UnityEngine.Networking;


public class ArenaManager : MonoBehaviour
{
    public List<GameObject> arenaPrefabs = new List<GameObject>(); // Menggunakan List<GameObject> untuk menyimpan prefabs
    private int selectedArenaIndex = 0; // Default selected index

    public GameObject arenaskin, Alert;
    public static ArenaManager Instance;
    public SpriteRenderer sr;
    public List<Sprite> arena = new List<Sprite>();
    private int selectedArena;
    private bool[] isArenaLocked;

    public GameObject lockedArena5; // GameObject yang mewakili arena 5 yang dikunci
    public GameObject lockedArena6; // GameObject yang mewakili arena 6 yang dikunci


    public string baseUrl;
    string tokenUser, value6, value7;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        tokenUser = PlayerPrefs.GetString("token");
        StartCoroutine(GetStoryMode(tokenUser));
        // Inisialisasi array isArenaLocked

    }

    IEnumerator GetStoryMode(string authToken)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(baseUrl + "/api/story/"))
        {
            // Tambahkan header "Authorization" dengan nilai token ke dalam permintaan
            www.SetRequestHeader("Authorization", "Bearer " + authToken);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Data dari Server: " + responseText);

                JSONNode responseData = JSON.Parse(responseText);
                string level_6 = responseData["data"]["level_6"];
                string level_7 = responseData["data"]["level_7"];

                value6 = level_6;
                value7 = level_7;

                Debug.Log("Level 6: " + level_6);
                Debug.Log("Level 7: " + level_7);

                isArenaLocked = new bool[arena.Count];

                if (level_6 == "locked")
                {
                    isArenaLocked[5] = true;
                }
                else
                {
                    isArenaLocked[7] = true;
                }

                if (level_7 == "locked")
                {
                    isArenaLocked[6] = true;
                }
                else
                {
                    isArenaLocked[8] = true;
                }

                // Lakukan pengolahan data sesuai kebutuhan Anda di sini
            }
        }
    }

    public void StartBattle()
    {
        if (selectedArenaIndex < 0 || selectedArenaIndex >= arenaPrefabs.Count)
        {
            Debug.LogError("SelectedArenaIndex is out of range.");
            return;
        }
        if ((value6 == "locked" && selectedArenaIndex == 5) || (value7 == "locked" && selectedArenaIndex == 6))
        {
            Alert.SetActive(true);
        }
        else
        {
            Debug.Log("Terbuka Bro");
            PlayerPrefs.SetInt("SelectedArenaIndex", selectedArenaIndex);
            SceneManager.LoadScene("Pertarungan");
        }

        // if (value6 == "locked" && value7 == "locked")
        // {
        //     if (selectedArenaIndex == 5 || selectedArenaIndex == 6)
        //     {
        //         Alert.SetActive(true);
        //     }
        //     else
        //     {
        //         Debug.Log("Terbuka Bro");
        //         PlayerPrefs.SetInt("SelectedArenaIndex", selectedArenaIndex);
        //         SceneManager.LoadScene("Pertarungan");
        //     }
        // }
        // else if (value6 == "locked")
        // {
        //     if (selectedArenaIndex == 5)
        //     {
        //         Alert.SetActive(true);
        //     }
        //     else
        //     {
        //         Debug.Log("Terbuka Bro");
        //         PlayerPrefs.SetInt("SelectedArenaIndex", selectedArenaIndex);
        //         SceneManager.LoadScene("Pertarungan");
        //     }
        // }
        // else if (value7 == "locked")
        // {
        //     if (selectedArenaIndex == 6)
        //     {
        //         Alert.SetActive(true);
        //     }
        //     else
        //     {
        //         Debug.Log("Terbuka Bro");
        //         PlayerPrefs.SetInt("SelectedArenaIndex", selectedArenaIndex);
        //         SceneManager.LoadScene("Pertarungan");
        //     }
        // }
        // else
        // {
        //     Debug.Log("Terbuka Cuy");
        //     PlayerPrefs.SetInt("SelectedArenaIndex", selectedArenaIndex);
        //     SceneManager.LoadScene("Pertarungan");
        // }
    }


    public void HiddenAlert()
    {
        Alert.SetActive(false);
    }

    public GameObject GetSelectedArenaPrefab()
    {
        if (selectedArenaIndex >= 0 && selectedArenaIndex < arenaPrefabs.Count)
        {
            return arenaPrefabs[selectedArenaIndex];
        }
        else
        {
            Debug.LogError("Selected arena prefab index out of range.");
            return null;
        }
    }

    public void OnStartBattleButtonClicked()
    {
        StartBattle();
    }

    public void NextOption()
    {
        do
        {
            selectedArena = (selectedArena + 1) % arena.Count;
        }
        while (isArenaLocked[selectedArena]); // Cek apakah arena terkunci

        sr.sprite = arena[selectedArena];
        selectedArenaIndex = (selectedArenaIndex + 1) % arenaPrefabs.Count;
        UpdateArenaPrefab();
    }

    public void BackOption()
    {
        do
        {
            selectedArena = (selectedArena - 1 + arena.Count) % arena.Count;
        }
        while (isArenaLocked[selectedArena]); // Cek apakah arena terkunci

        sr.sprite = arena[selectedArena];
        selectedArenaIndex = (selectedArenaIndex - 1 + arenaPrefabs.Count) % arenaPrefabs.Count;
        UpdateArenaPrefab();
    }

    private void UpdateArenaPrefab()
    {
        if (arenaskin != null && selectedArenaIndex < arenaPrefabs.Count)
        {
            // Hapus arena sebelumnya jika ada
            foreach (Transform child in arenaskin.transform)
            {
                Destroy(child.gameObject);
            }

            // Instansiasi prefab arena yang sesuai di posisi arenaskin
            Instantiate(arenaPrefabs[selectedArenaIndex], arenaskin.transform.position, Quaternion.identity, arenaskin.transform);
        }
        else
        {
            Debug.LogError("Arena prefab or selected arena index not set properly.");
        }
    }
}
