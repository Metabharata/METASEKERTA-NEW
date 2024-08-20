using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState
{
    None,
    Pukul,
    Senjata,
    Defense,
    Ulti
}
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation myAnim;
    private bool activateTimeToReset;
    private float defaultComboTimer = 0.5f;
    private float currentComboTimer;
    public bool isDefense;
    private ComboState currentComboState;
    public Transform ultiPosition;
    public GameObject ulti;

    [SerializeField]
    private GameObject pukulAttackPoint;

    [SerializeField]
    private GameObject senjataAttackPoint;
    private ManaHandler manaHandler;



    // public bool isDefense;

    private void Awake()
    {
        myAnim = GetComponent<CharacterAnimation>();
        manaHandler = GetComponent<ManaHandler>();
    }
    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.None;
    }

    private void Update()
    {

        // ComboAttack();
        ResetComboState();
    }

    // void ComboAttack()
    // {
    //     if (Input.GetKeyDown(KeyCode.W))
    //     {
    //         if (currentComboState == ComboState.Pukul || currentComboState == ComboState.Senjata)
    //         {
    //             return;
    //         }
    //         currentComboState++;
    //         activateTimeToReset = true;
    //         currentComboTimer = defaultComboTimer;

    //         if (currentComboState == ComboState.Pukul)
    //         {
    //             myAnim.Pukul();
    //         }
    //         if (currentComboState == ComboState.Senjata)
    //         {
    //             myAnim.Senjata();
    //         }
    //     }
    //     if (Input.GetKeyDown(KeyCode.D))
    //     {
    //         if (currentComboState == ComboState.Pukul || currentComboState == ComboState.Senjata)
    //         {
    //             return;
    //         }
    //         if (currentComboState == ComboState.None || currentComboState == ComboState.Pukul || currentComboState == ComboState.Senjata)
    //         {

    //             currentComboState = ComboState.Senjata;
    //         }
    //         activateTimeToReset = true;
    //         currentComboTimer = defaultComboTimer;
    //         if (currentComboState == ComboState.Senjata)
    //         {
    //             myAnim.Senjata();
    //         }

    //     }



    // }
    public void PukulButtonClicked()
    {
        if (currentComboState != ComboState.None)
        {
            return; // Keluar dari metode jika sedang dalam keadaan Pukul atau Senjata
        }

        currentComboState = ComboState.Pukul; // Set combo state menjadi Pukul
        activateTimeToReset = true;
        currentComboTimer = defaultComboTimer;

        myAnim.Pukul(); // Memanggil animasi Pukul
    }

    public void SenjataButtonClicked()
    {
        if (currentComboState != ComboState.None)
        {
            return; // Keluar dari metode jika sedang dalam keadaan Pukul atau Senjata
        }
        // Debug.Log(manaHandler.CurrentMana);
        // Debug.Log(manaHandler.maxMana);
        if (manaHandler.CurrentMana >= manaHandler.maxMana)
        {
            currentComboState = ComboState.Senjata; // Set combo state menjadi Senjata
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            myAnim.Senjata(); // Memanggil animasi Senjata

            int direction = (int)Mathf.Sign(transform.localScale.x);
            GameObject ultiInstance = Instantiate(ulti, ultiPosition.position, Quaternion.identity);
            Ulti ultiScript = ultiInstance.GetComponent<Ulti>();
            if (ultiScript != null)
            {
                ultiScript.SetDirection(direction);
            }

            manaHandler.UseSkill();
        }
    }


    public void BertahanButtonClicked()
    {
        if (currentComboState == ComboState.Pukul || currentComboState == ComboState.Senjata)
        {
            return;
        }

        currentComboState = ComboState.Defense;
        activateTimeToReset = true;
        currentComboTimer = defaultComboTimer;

        // Mengaktifkan animasi bertahan di sini
        isDefense = true; // Mengatur karakter bertahan
        myAnim.Defense(isDefense); // Memanggil metode Defense dengan argumen isDefense
        Debug.Log("Bertahan: On");
    }

    public void BertahanButtonReleased()
    {
        if (currentComboState == ComboState.Defense)
        {
            currentComboState = ComboState.None;
            activateTimeToReset = false;
            isDefense = false; // Mengatur karakter tidak bertahan
            myAnim.Defense(isDefense); // Memanggil metode Defense dengan argumen isDefense
            Debug.Log("Bertahan: Off");
        }
    }
    public void ActivePukul()
    {
        pukulAttackPoint.SetActive(true);
    }
    public void ActiveSenjata()
    {
        senjataAttackPoint.SetActive(true);
    }
    public void DeactivePukul()
    {
        pukulAttackPoint.SetActive(false);
    }
    public void DeactiveSenjata()
    {
        senjataAttackPoint.SetActive(false);
    }
    public void DeactiveAllAttack()
    {
        pukulAttackPoint.SetActive(false);
        senjataAttackPoint.SetActive(false);

    }

    void ResetComboState()
    {
        if (activateTimeToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.None;
                activateTimeToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}