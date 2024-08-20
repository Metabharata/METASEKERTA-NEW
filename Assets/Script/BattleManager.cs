using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;
    public Transform arenaSpawn;
    public GameObject[] playerCharacterPrefabs;
    public GameObject[] enemyCharacterPrefabs;
    public GameObject[] arenaPrefabs;


    private GameObject playerCharacterInstance;
    public PlayerController playerController;
    public PlayerAttack playerAttack;
    public PertarunganBebasAttack pertarunganBebasAttack;

    public GameObject canvas; // Referensi ke Canvas yang berisi ManaHandler

    private ManaHandler manaHandler;
    private CharacterManager characterManager;

    private int selectedPlayerCharacterIndex;
    private int selectedEnemyCharacterIndex;
    private int selectedArenaIndex;


    // private void Awake()
    // {
    //     selectedPlayerCharacterIndex = PlayerPrefs.GetInt("SelectedPlayerCharacterIndex");
    //     selectedEnemyCharacterIndex = PlayerPrefs.GetInt("SelectedEnemyCharacterIndex");
    //     selectedArenaIndex = PlayerPrefs.GetInt("SelectedArenaIndex");

    //     // Buat pengecekan jika nilai tidak sama dengan null atau string kosong
    //     if (selectedPlayerCharacterIndex != 0 && selectedEnemyCharacterIndex != 0 && selectedArenaIndex != 0)
    //     {
    //         InstantiatePlayerCharacter();
    //         InstantiateEnemyCharacter();
    //         InstantiateArena();
    //     }
    //     else
    //     {
    //         // Handle jika ada nilai yang kosong atau null
    //         Debug.LogError("Ada nilai yang kosong atau null.");
    //     }


    // }

    private void Start()
    {
        selectedPlayerCharacterIndex = PlayerPrefs.GetInt("SelectedPlayerCharacterIndex");
        selectedEnemyCharacterIndex = PlayerPrefs.GetInt("SelectedEnemyCharacterIndex");
        selectedArenaIndex = PlayerPrefs.GetInt("SelectedArenaIndex");

        InstantiatePlayerCharacter();
        InstantiateEnemyCharacter();
        InstantiateArena();

        playerController = playerCharacterInstance.GetComponent<PlayerController>();
        playerAttack = playerCharacterInstance.GetComponent<PlayerAttack>();
        manaHandler = canvas.GetComponentInChildren<ManaHandler>();
        // pertarunganBebasAttack = playerCharacterInstance.GetComponent<PertarunganBebasAttack>();

        // playerCharacterInstance = GameObject.FindGameObjectWithTag("Player"); // Tag the player prefab as "Player" in the hierarchy
        // playerAttackInstance = playerCharacterInstance.GetComponentInChildren<PlayerAttack>().gameObject;

        // characterManager = GetComponent<CharacterManager>();
    }


    private void InstantiatePlayerCharacter()
    {
        if (selectedPlayerCharacterIndex >= 0 && selectedPlayerCharacterIndex < playerCharacterPrefabs.Length)
        {
            GameObject playerPrefab = playerCharacterPrefabs[selectedPlayerCharacterIndex];
            if (playerPrefab != null)
            {
                playerCharacterInstance = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("No selected player character prefab found.");
            }
        }
        else
        {
            Debug.LogError("Selected player character index is out of bounds.");
        }
    }

    private void InstantiateEnemyCharacter()
    {
        GameObject enemyPrefab = enemyCharacterPrefabs[selectedEnemyCharacterIndex];
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No selected enemy character prefab found.");
        }
    }
    private void InstantiateArena()
    {
        GameObject arenaPrefab = ArenaManager.Instance.GetSelectedArenaPrefab();
        if (arenaPrefab != null)
        {
            Instantiate(arenaPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No selected arena prefab found.");
        }
    }

    public void OnPukulButtonClicked()
    {
        playerAttack.PukulButtonClicked();
        ActivatePlayerAttackPoint();
        // myAnim.Pukul();
        Debug.Log("Berhasil");
    }

    public void OnSenjataButtonClicked()
    {
        playerAttack.SenjataButtonClicked();
        ActivateSenjataAttackPoint();
        // myAnim.Senjata();
        Debug.Log("bisa");
    }

    public void OnJumpButtonClicked()
    {
        playerController.Jump(); // Panggil metode Jump pada PlayerController
    }

    public void OnKananButtonClicked()
    {
        playerController.MoveRight(); // Panggil metode MoveRight pada PlayerController
    }

    public void OnKiriButtonClicked()
    {
        playerController.MoveLeft(); // Panggil metode MoveLeft pada PlayerController
    }

    public void OnStopButtonClicked()
    {
        playerController.StopMoving(); // Panggil metode StopMoving pada PlayerController
    }

    public void OnBertahanButtonClicked()
    {
        playerAttack.BertahanButtonClicked();
    }

    public void OnBertahanButtonRelease()
    {
        playerAttack.BertahanButtonReleased();
    }
    public void ActivatePlayerAttackPoint()
    {
        playerAttack.ActivePukul();
    }
    public void ActivateSenjataAttackPoint()
    {
        playerAttack.ActiveSenjata();
    }

    // public void DeactivatePlayerAttackPoint()
    // {
    //     playerAttack.DeactivePukul();
    //     playerAttack.DeactiveSenjata();
    // }
    // public void EndAttack()
    // {
    //     DeactivatePlayerAttackPoint(); // Panggil fungsi nonaktifkan attack point
    // }

    // public void ActivePukul()
    // {
    //     pukulAttackPoint.SetActive(true);
    // }
    // public void ActiveSenjata()
    // {
    //     senjataAttackPoint.SetActive(true);
    // }
    // public void DeactivePukul()
    // {
    //     playerAttack.pukulAttackPoint.SetActive(false);
    // }
    // public void DeactiveSenjata()
    // {
    //     playerAttack.senjataAttackPoint.SetActive(false);
    // }
    // public void DeactiveAllAttack()
    // {
    //     playerAttack.pukulAttackPoint.SetActive(false);
    //     playerAttack.senjataAttackPoint.SetActive(false);

    // }


    // private void SetBattleArenaBackground()
    // {
    //     if (battleArenaBackground != null && selectedArenaIndex < ArenaManager.Instance.arena.Count)
    //     {
    //         battleArenaBackground.sprite = ArenaManager.Instance.arena[selectedArenaIndex];
    //     }
    //     else
    //     {
    //         Debug.LogError("Arena background or selected arena index not set properly.");
    //     }
    // }
}
