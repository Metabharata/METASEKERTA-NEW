using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] characters1;
    public GameObject[] characters2;
    public GameObject select1, select2, button1, button1Cencel, nextButton;
    public bool SelectPlayercharacter = false;
    public bool SelectEnemycharacter = false;
    private int selectedPlayerCharacterIndex = -1;
    private int selectedEnemyCharacterIndex = -1;
    public Image[] characterLockImages;
    public GameObject BabSatuLock, BabSatuUnlock;
    private bool[] unlockedCharacters;
    private bool[] unlockedCharacters2;
    // public GameControler gameControler;
    private int lastCompletedChapter = 7;
    public GameObject alertKarakter;

    public GameObject Index2, Indexs2, EnemyIndex2, EnemyIndexs2, IndexBima, IndexDuryu, EnemyBima, EnemyDuryu, IndexArjuna, IndexBatara, EnemyArjuna, EnemyBatara, IndexHanoman, EnemyHanoman, IndexCitrasena, EnemyCitrasena;

    public static MenuManager Instance;

    string BabSatuActive, BabDuaActive;
    string conditionBab;
    private Dictionary<int, string> characterSceneMap = new Dictionary<int, string>
    {
        { 3, "SceneNakula" },
        { 4, "SceneSadewa" },
        { 7, "SceneSalya" },
        { 8, "SceneDrupadi" },
        { 9, "SceneDusasana" },
        { 11, "SceneAbimanyu" },
        { 12, "SceneKresna" },
        { 15, "SceneYudistira" },
        { 16, "SceneSangkuni" },
        { 17, "SceneBima" },
        { 18, "SceneDuyudana" },
        { 19, "SceneArjuna" },
        { 20, "SceneBarata" },
        { 21, "SceneAnoman" },
        { 22, "SceneCitrasena" },
    };

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
        unlockedCharacters = new bool[characters1.Length];
        unlockedCharacters2 = new bool[characters2.Length];

        bool babSatuSelesai = PlayerPrefs.GetString("BabSatuSelesaiMeta") == "BabSatu";
        bool babDuaSelesai = PlayerPrefs.GetString("BabDuaSelesaiMeta") == "BabDua";
        bool babTigaSelesai = PlayerPrefs.GetString("BabTigaSelesaiMeta") == "BabTiga";
        bool babEmpatSelesai = PlayerPrefs.GetString("BabEmpatSelesaiMeta") == "BabEmpat";
        bool babLimaSelesai = PlayerPrefs.GetString("BabLimaSelesaiMeta") == "BabLima";


        Debug.Log(babSatuSelesai);

        // Inisialisasi karakter terkunci dengan true atau false'

        // Ini Buat Player Utama
        if (babSatuSelesai && babDuaSelesai && babTigaSelesai && babEmpatSelesai && babLimaSelesai)
        {
            // Debug.Log("BabLima");
            for (int i = 0; i < characters1.Length; i++)
            {

                if (i == 0)
                {
                    unlockedCharacters[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22)
                {
                    unlockedCharacters[i] = true;
                    Debug.Log(unlockedCharacters[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);

                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);


                    IndexArjuna.SetActive(false);
                    IndexBatara.SetActive(false);
                    EnemyArjuna.SetActive(false);
                    EnemyBatara.SetActive(false);

                    IndexHanoman.SetActive(false);
                    EnemyHanoman.SetActive(false);

                    IndexCitrasena.SetActive(false);
                    EnemyHanoman.SetActive(false);
                }
                else
                {
                    unlockedCharacters[i] = false;
                }
            }
        }
        else if (babSatuSelesai && babDuaSelesai && babTigaSelesai && babEmpatSelesai)
        {
            Debug.Log("BabDua");
            for (int i = 0; i < characters1.Length; i++)
            {

                if (i == 0)
                {
                    unlockedCharacters[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20 || i == 21)
                {
                    unlockedCharacters[i] = true;
                    Debug.Log(unlockedCharacters[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);

                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);


                    IndexArjuna.SetActive(false);
                    IndexBatara.SetActive(false);
                    EnemyArjuna.SetActive(false);
                    EnemyBatara.SetActive(false);

                    IndexHanoman.SetActive(false);
                    EnemyHanoman.SetActive(false);
                }
                else
                {
                    unlockedCharacters[i] = false;
                }
            }
        }
        else if (babSatuSelesai && babDuaSelesai && babTigaSelesai)
        {
            Debug.Log("BabDua");
            for (int i = 0; i < characters1.Length; i++)
            {

                if (i == 0)
                {
                    unlockedCharacters[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20)
                {
                    unlockedCharacters[i] = true;
                    Debug.Log(unlockedCharacters[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);

                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);


                    IndexArjuna.SetActive(false);
                    IndexBatara.SetActive(false);
                    EnemyArjuna.SetActive(false);
                    EnemyBatara.SetActive(false);
                }
                else
                {
                    unlockedCharacters[i] = false;
                }
            }
        }
        else if (babSatuSelesai && babDuaSelesai)
        {
            Debug.Log("BabDua");
            for (int i = 0; i < characters1.Length; i++)
            {

                if (i == 0)
                {
                    unlockedCharacters[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18)
                {
                    unlockedCharacters[i] = true;
                    Debug.Log(unlockedCharacters[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);

                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);
                }
                else
                {
                    unlockedCharacters[i] = false;
                }
            }
        }
        else if (babSatuSelesai)
        {
            Debug.Log("BabSatu");
            for (int i = 0; i < characters1.Length; i++)
            {
                // Debug.Log(i);

                if (i == 0)
                {
                    unlockedCharacters[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16)
                {
                    unlockedCharacters[i] = true;
                    Debug.Log(unlockedCharacters[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);

                }
                else
                {
                    unlockedCharacters[i] = false;
                }
            }

        }
        else
        {
            for (int i = 0; i < characters1.Length; i++)
            {
                if (i == 0)
                {
                    unlockedCharacters[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12)
                {
                    unlockedCharacters[i] = true;
                }
                else
                {
                    unlockedCharacters[i] = false;
                }
            }
        }




        // Ini Buat Enemy
        if (babSatuSelesai && babDuaSelesai && babTigaSelesai && babEmpatSelesai && babLimaSelesai)
        {
            for (int i = 0; i < characters2.Length; i++)
            {
                // Debug.Log(i);

                if (i == 0)
                {
                    unlockedCharacters2[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22)
                {
                    unlockedCharacters2[i] = true;
                    Debug.Log(unlockedCharacters2[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);
                    //pisah
                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);
                    //pisah
                    IndexArjuna.SetActive(false);
                    IndexBatara.SetActive(false);
                    EnemyArjuna.SetActive(false);
                    EnemyBatara.SetActive(false);
                    //pisah
                    IndexHanoman.SetActive(false);
                    EnemyHanoman.SetActive(false);

                    IndexCitrasena.SetActive(false);
                    EnemyCitrasena.SetActive(false);
                }
                else
                {
                    unlockedCharacters2[i] = false;
                }
            }
        }
        else if (babSatuSelesai && babDuaSelesai && babTigaSelesai && babEmpatSelesai)
        {
            for (int i = 0; i < characters2.Length; i++)
            {
                // Debug.Log(i);

                if (i == 0)
                {
                    unlockedCharacters2[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20 || i == 21)
                {
                    unlockedCharacters2[i] = true;
                    Debug.Log(unlockedCharacters2[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);
                    //pisah
                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);
                    //pisah
                    IndexArjuna.SetActive(false);
                    IndexBatara.SetActive(false);
                    EnemyArjuna.SetActive(false);
                    EnemyBatara.SetActive(false);
                    //pisah
                    IndexHanoman.SetActive(false);
                    EnemyHanoman.SetActive(false);
                }
                else
                {
                    unlockedCharacters2[i] = false;
                }
            }
        }
        else if (babSatuSelesai && babDuaSelesai && babTigaSelesai)
        {
            for (int i = 0; i < characters2.Length; i++)
            {
                // Debug.Log(i);

                if (i == 0)
                {
                    unlockedCharacters2[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20)
                {
                    unlockedCharacters2[i] = true;
                    Debug.Log(unlockedCharacters2[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);
                    //pisah
                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);
                    //pisah
                    IndexArjuna.SetActive(false);
                    IndexBatara.SetActive(false);
                    EnemyArjuna.SetActive(false);
                    EnemyBatara.SetActive(false);
                }
                else
                {
                    unlockedCharacters2[i] = false;
                }
            }
        }
        else if (babSatuSelesai && babDuaSelesai)
        {
            for (int i = 0; i < characters2.Length; i++)
            {
                // Debug.Log(i);

                if (i == 0)
                {
                    unlockedCharacters2[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16 || i == 17 || i == 18)
                {
                    unlockedCharacters2[i] = true;
                    Debug.Log(unlockedCharacters2[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);
                    //pisah
                    IndexBima.SetActive(false);
                    IndexDuryu.SetActive(false);
                    EnemyBima.SetActive(false);
                    EnemyDuryu.SetActive(false);
                    Debug.Log("coba");
                }
                else
                {
                    unlockedCharacters2[i] = false;
                }
            }
        }
        else if (babSatuSelesai)
        {
            for (int i = 0; i < characters2.Length; i++)
            {
                // Debug.Log(i);

                if (i == 0)
                {
                    unlockedCharacters2[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 15 || i == 16)
                {
                    unlockedCharacters2[i] = true;
                    Debug.Log(unlockedCharacters2[i]);
                    Index2.SetActive(false);
                    Indexs2.SetActive(false);
                    EnemyIndex2.SetActive(false);
                    EnemyIndexs2.SetActive(false);

                }
                else
                {
                    unlockedCharacters2[i] = false;
                }
            }

        }
        else
        {
            for (int i = 0; i < characters2.Length; i++)
            {
                if (i == 0)
                {
                    unlockedCharacters2[i] = false;
                }
                else if (i == 3 || i == 4 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12)
                {
                    unlockedCharacters2[i] = true;
                }
                else
                {
                    unlockedCharacters2[i] = false;
                }
            }
        }




    }
    public void UnlockSpecificCharacters(int[] indices)
    {
        for (int i = 0; i < indices.Length; i++)
        {
            int index = indices[i];
            if (index >= 0 && index < unlockedCharacters.Length)
            {
                unlockedCharacters[index] = true;
            }
        }

        UpdateCharacterLockUI();
    }


    private void Start()
    {
        int bukaKarakterBabSatu = PlayerPrefs.GetInt("BukaKarakterBabSatu", 0);

        if (bukaKarakterBabSatu == 7)
        {
            PlayerPrefs.SetInt("BukaKarakterBabSatu", 0);
            UnlockAllCharacters();
            BabSatuLock.SetActive(false);
            BabSatuUnlock.SetActive(true);

        }
        else
        {
            BabSatuLock.SetActive(true);
            BabSatuUnlock.SetActive(false);

        }
    }

    public void Next()
    {
        if (SelectPlayercharacter && SelectEnemycharacter && lastCompletedChapter >= 7)
        {
            PlayerPrefs.SetInt("SelectedPlayerCharacterIndex", selectedPlayerCharacterIndex);
            PlayerPrefs.SetInt("SelectedEnemyCharacterIndex", selectedEnemyCharacterIndex);
            SceneManager.LoadScene("Arena");
        }
        else
        {
            Debug.Log("Pilih karakter untuk kedua tim atau selesaikan bab sebelumnya sebelum melanjutkan!");
        }
    }

    public void selectCharakter1()
    {
        // select1.SetActive(false);
        // select2.SetActive(true);
        // button1.SetActive(false);
        // // button1Cencel.SetActive(true);
        // BabSatuLock.SetActive(false);
        // BabSatuUnlock.SetActive(false);
        PlayerPrefs.SetInt("SelectedPlayerCharacterIndex", selectedPlayerCharacterIndex);
        Debug.Log(selectedPlayerCharacterIndex);

        // Check if the selectedPlayerCharacterIndex is in the dictionary
        if (characterSceneMap.ContainsKey(selectedPlayerCharacterIndex))
        {
            // Load the corresponding scene
            SceneManager.LoadScene(characterSceneMap[selectedPlayerCharacterIndex]);
        }
        else
        {
            Debug.LogError("Invalid selectedPlayerCharacterIndex.");
        }



    }

    public void cencelCharackter1()
    {
        select1.SetActive(true);
        select2.SetActive(false);
        button1.SetActive(true);
        button1Cencel.SetActive(false);
    }
    public void lanjutkan()
    {
        SceneManager.LoadScene("PilihKarakter");
    }
    public void SelectPlayerCharacter(int index)
    {
        Debug.Log(unlockedCharacters[index]);
        Debug.Log(index);
        // if(index == 21)
        // {
        //     Debug.Log("jalan");
        // }
        
        // else if (!unlockedCharacters[index])
        // {
        //     alertKarakter.SetActive(true);
        //     Debug.Log("Karakter ini masih terkunci. Selesaikan pertarungan bab sebelumnya untuk membuka karakte.");
        //     return;
        // }

        foreach (GameObject character in characters1)
        {
            character.SetActive(false);
        }

        characters1[index].SetActive(true);
        Debug.Log("Karakter pemain dipilih: " + characters1[index].name);

        selectedPlayerCharacterIndex = index;
        SelectPlayercharacter = true;
        // UpdateNextButtonInteractable();
    }

    // public void SelectEnemyCharacter(int index)
    // {
    //     if (!unlockedCharacters[index])
    //     {
    //         alertKarakter.SetActive(true);
    //         Debug.Log("Karakter ini masih terkunci. Selesaikan pertarungan bab sebelumnya untuk membuka karakter.");
    //         return;
    //     }

    //     foreach (GameObject character in characters2)
    //     {
    //         character.SetActive(false);
    //     }

    //     characters2[index].SetActive(true);
    //     Debug.Log("Karakter musuh dipilih: " + characters2[index].name);

    //     selectedEnemyCharacterIndex = index;
    //     SelectEnemycharacter = true;
    //     UpdateNextButtonInteractable();
    // }

    private void UpdateNextButtonInteractable()
    {
        nextButton.SetActive(SelectPlayercharacter && SelectEnemycharacter);
    }
    public void OnChapterOneCompleted()
    {
        UnlockAllCharacters();
        UpdateCharacterLockUI();
        // alertManager.HideAlert();
    }
    // Method untuk membuka karakter setelah menyelesaikan bab tertentu
    public void UnlockAllCharacters()
    {
        for (int i = 0; i < unlockedCharacters.Length; i++)
        {
            if (i == 2 || i == 14)
            {
                unlockedCharacters[i] = true;
            }
            else
            {
                unlockedCharacters[i] = false;
            }

            // Perbarui UI karakter yang terkunci
            if (characterLockImages[i] != null)
            {
                characterLockImages[i].gameObject.SetActive(!unlockedCharacters[i]);
            }
        }
    }

    // Metode untuk memperbarui tampilan UI karakter yang terkunci
    private void UpdateCharacterLockUI()
    {
        for (int i = 0; i < characters1.Length; i++)
        {
            if (!unlockedCharacters[i])
            {
                // Sembunyikan UI Gambar Kunci untuk karakter terkunci
                characterLockImages[i].gameObject.SetActive(true);
            }
            else
            {
                characterLockImages[i].gameObject.SetActive(false);
            }
        }
    }
}
