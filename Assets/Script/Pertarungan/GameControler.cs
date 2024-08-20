using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    // [SerializeField]
    // private Slider bgmVolumeSlider;
    public static GameControler gameControler; // Perbaikan typo 'statis' menjadi 'static'
    public GameObject winPanel;
    public GameObject losePanel;
    // public MenuManager menuManager; // Referensi ke MenuManager
    [SerializeField]
    private Slider bgmVolumeSlider; // Slider untuk mengatur volume BGM
    [SerializeField]
    private Slider soundEffectVolumeSlider; // Slider untuk mengatur volume efek suara


    public bool isGameFinished;
    public bool isEnemyDead;
    public bool isPlayerDead;
    public bool isEnemyWin;
    public bool isPlayerWin;

    public float playerHealth;
    public float enemyHealth;
    // public int playerCode;
    // public int enemyCode;

    // [SerializeField]
    // private List<GameObject> playerChar;
    // [SerializeField]
    // private List<GameObject> enemyChar;

    void Awake()
    {
        gameControler = this; // Menggunakan 'gameControler' yang benar
        // playerCode = CodeOfChar.codeOfChar.playerCode;
        // enemyCode = CodeOfChar.codeOfChar.enemyCode;
        // SpawnChar(playerCode, enemyCode);
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioControler.audioControler.AllStopSound("BGM1, arrow,pukul");
        AudioControler.audioControler.PlayBGMSound("BGM1");
        isGameFinished = false;
        bgmVolumeSlider.onValueChanged.AddListener(UpdateBGMVolume);
        soundEffectVolumeSlider.onValueChanged.AddListener(UpdateSoundEffectVolume);
    }



    void Update()
    {
        CheckGameFinish();
        UpdateUI();
    }

    // public void BukaKarakterTerkunci()
    // {
    //     if (menuManager != null)
    //     {
    //         menuManager.BukaKarakter(4); // Contoh: Membuka karakter di indeks ke-4
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Referensi MenuManager tidak ditemukan.");
    //     }
    // }
    public void UpdateBGMVolume(float volume)
    {
        AudioControler.audioControler.SetBGMVolume(volume); // Mengatur volume BGM
    }

    public void UpdateSoundEffectVolume(float volume)
    {
        AudioControler.audioControler.SetSoundEffectVolume(volume); // Mengatur volume efek suara
    }
    public void CheckGameFinish()
    {
        if (isGameFinished)
            return;

        if (playerHealth <= 0)
        {
            isGameFinished = true;
            isEnemyWin = true;
        }
        else if (enemyHealth <= 0)
        {
            isGameFinished = true;
            isPlayerWin = true;
        }

        if (isGameFinished)
        {
            if (isPlayerWin)
            {
                Time.timeScale = 0; // Menghentikan permainan
                winPanel.SetActive(true);
                Debug.Log("berhenti");
            }
            else if (isEnemyWin)
            {
                Time.timeScale = 0; // Menghentikan permainan
                losePanel.SetActive(true);
            }
        }
    }

    void UpdateUI()
    {
        // Implement your UI update logic here
    }

    // void SpawnChar(int code1, int code2)
    // {
    //     Instantiate(playerChar[code1]);
    //     Instantiate(enemyChar[code2]);
    // }

    // ...
}
