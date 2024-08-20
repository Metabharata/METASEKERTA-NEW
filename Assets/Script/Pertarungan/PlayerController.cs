using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState1
{
    None,
    Pukul,
    Senjata,
    Defense
}
public class PlayerController : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    public float forceJump;
    private CharacterAnimation myAnim;

    private bool facingRight;
    public bool isJumping;
    public bool isGrounded;
    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isMoving;
    private bool isHurt;
    private bool activateTimeToReset;
    private float defaultComboTimer = 0.5f;
    private float currentComboTimer;
    private ComboState1 currentComboState;
    public bool isDefense;
    public float pukulDamage;
    public float senjataDamage;
    public bool isDie;

    private EnemyController GetEnemy;
    private Health myHealth;
    private Mana myMana;

    [SerializeField]
    private BarStart healthBar;
    [SerializeField]
    private ManaStart manaBar;



    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<CharacterAnimation>();
        myMana = GetComponent<Mana>();
        myHealth = GetComponent<Health>();
        healthBar.bar = GameObject.FindGameObjectWithTag(Tags.Player_Health_Bar).GetComponent<BarScript>();
        // healthBar.Initialize();
        if (healthBar.bar != null)
        {
            healthBar.Initialize();
        }
        else
        {
            Debug.LogWarning("Health bar reference is not valid.");
        }
        manaBar.manaScript = GameObject.FindGameObjectWithTag(Tags.Player_Mana_Bar).GetComponent<ManaScript>();
        if (manaBar.manaScript != null)
        {
            manaBar.Initialize();
        }
        else
        {
            Debug.LogWarning("Mana bar reference is not valid.");
        }
    }

    private void Start()
    {
        GetEnemy = GameObject.FindGameObjectWithTag(Tags.Enemy_Tags).GetComponent<EnemyController>();
        facingRight = true;
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState1.None;
        healthBar.MaxVal = myHealth.maxHealth;
        // manaBar.manaScript.MaxVal = myMana.maxMana;
    }

    private void Update()
    {
        // Jump();
        DeathCheck();
        healthBar.CurrentVal = myHealth.health;
        // manaBar.CurrentVal = myMana.mana;
        GameControler.gameControler.playerHealth = myHealth.health;
    }

    private void FixedUpdate()
    {
        if (isMovingLeft)
        {
            HandleMovement(-1);
        }
        else if (isMovingRight)
        {
            HandleMovement(1);
        }
        else
        {
            StopMoving();
        }

        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);
        if (isDie)
            return;
        healthBar.CurrentVal = myHealth.health;
        // manaBar.CurrentVal = myMana.mana;
        // manaBar.manaScript.MaxVal = myMana.maxMana;
        if (GameControler.gameControler.isGameFinished)
            return;
    }
    public void MoveLeft()
    {
        if (isDie)
            return;
        isMoving = true;
        isMovingLeft = true;
    }

    public void MoveRight()
    {
        if (isDie)
            return;
        isMoving = true;
        isMovingRight = true;
    }
    public void StopMoving()
    {
        if (isDie)
            return;
        isMoving = false;
        isMovingLeft = false;
        isMovingRight = false;
        myRigidbody.velocity = Vector2.zero; // Menghentikan pergerakan
        myAnim.Walk(0); // Menghentikan animasi berjalan

    }
    public void StopMovingLeft()
    {
        if (isDie)
            return;
        isMovingLeft = false;
        StopMoving();
    }
    public void StopMovingRight()
    {
        if (isDie)
            return;
        isMovingRight = false;
        StopMoving();
    }


    private void HandleMovement(float horizontal)
    {
        if (isDie)
            return;
        if (horizontal != 0)
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
            myAnim.Walk(Mathf.Abs(horizontal)); // Menggunakan nilai absolut
            Flip(horizontal);
        }
    }

    private void Flip(float horizontal)
    {
        if (isDie)
            return;
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void DeathCheck()
    {
        if (GameControler.gameControler.isGameFinished)
            return;
        if (myHealth.health <= 0)
        {
            isDie = true;
            myAnim.Die(isDie);
            GameControler.gameControler.isPlayerDead = isDie;
        }
    }
    // public void StartJumpFromButton()
    // {
    //     myRigidbody.AddForce(new Vector2(0, forceJump));
    //     isJumping = true;
    //     myAnim.Jump(true);
    // }

    // public void StopJumpFromGround()
    // {
    //     isJumping = false;
    //     myAnim.Jump(false);
    // }
    public void Jump()
    {
        if (isDie)
            return;
        if (isGrounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0); // Menghentikan pergerakan vertikal sebelum melompat
            myRigidbody.AddForce(new Vector2(0, forceJump));
            myAnim.Jump(true); // Memulai animasi jump
        }
    }

    public void BertahanButtonClicked1()
    {
        if (isDie)
            return;
        if (currentComboState == ComboState1.Pukul || currentComboState == ComboState1.Senjata)
        {
            return;
        }

        currentComboState = ComboState1.Defense;
        activateTimeToReset = true;
        currentComboTimer = defaultComboTimer;

        // Mengaktifkan animasi bertahan di sini
        isDefense = true; // Mengatur karakter bertahan
        myAnim.Defense(isDefense); // Memanggil metode Defense dengan argumen isDefense
        Debug.Log("Bertahan: On");
    }

    public void BertahanButtonReleased()
    {
        if (isDie)
            return;
        if (currentComboState == ComboState1.Defense)
        {
            currentComboState = ComboState1.None;
            activateTimeToReset = false;
            isDefense = false; // Mengatur karakter tidak bertahan
            myAnim.Defense(isDefense); // Memanggil metode Defense dengan argumen isDefense
            Debug.Log("Bertahan: Off");
        }
    }
    private IEnumerator EndHurtAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Ganti angka ini sesuai durasi animasi "hurt"
        isHurt = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
            myAnim.Jump(false);
        }
        if (GameControler.gameControler.isGameFinished)
            return;
        if (collision.tag == Tags.Pukul_Attack_Tag || collision.tag == Tags.Senjata_Attack_Tag)
        {
            if (!isHurt && currentComboState != ComboState1.Defense) // Tambahkan cek apakah pemain sedang dalam keadaan terluka atau bertahan
            {
                isHurt = true;
                myAnim.Hurt();
                StartCoroutine(EndHurtAnimation());
                myHealth.health -= GetEnemy.pukulDamage;
                myHealth.health -= GetEnemy.senjataDamage;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
