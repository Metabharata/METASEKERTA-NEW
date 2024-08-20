using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float pukulDamage;
    public float senjataDamage;
    public bool isDie;
    private PlayerController GetPlayer;
    private Health myHealth;
    // public float pukulDamage;
    // public float senjataDamage;
    // public bool isDie;

    // private PlayerController GetPLayer;
    // private Health myHealth;
    private CharacterAnimation enemyAnim;
    private Rigidbody2D enemyRigidBody;
    [SerializeField]
    private float movementSpeed;
    private Mana myMana;
    private Transform playerTransform;
    private bool followPlayer;
    private bool attackPlayer;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private float chasePlayerAfterAttack;

    private float currentAttackTimer;
    [SerializeField]
    private float deffaultAttackTimer;

    private Collider2D playerCollider;
    private Vector3 initialScale;
    [SerializeField]
    private GameObject pukulAttackPoint;
    [SerializeField]
    private GameObject senjataAttackPoint;
    [SerializeField]
    private BarStart healthBar;
    [SerializeField]
    private ManaStart manaBar;




    void Awake()
    {
        myHealth = GetComponent<Health>();
        playerCollider = GameObject.FindGameObjectWithTag(Tags.Player_Tags).GetComponent<Collider2D>();
        enemyAnim = GetComponent<CharacterAnimation>();
        enemyRigidBody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag(Tags.Player_Tags).transform;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);
        initialScale = transform.localScale;
        healthBar.bar = GameObject.FindGameObjectWithTag(Tags.Enemy_Health_Bar).GetComponent<BarScript>();
        healthBar.Initialize();
        myMana = GetComponent<Mana>();
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

    void Start()
    {
        healthBar.MaxVal = myHealth.maxHealth;
        GetPlayer = GameObject.FindGameObjectWithTag(Tags.Player_Tags).GetComponent<PlayerController>();
        // facingRight = true;
        followPlayer = true;
        currentAttackTimer = deffaultAttackTimer;
        // manaBar.manaScript.MaxVal = myMana.maxMana;
    }

    void Update()
    {
        healthBar.CurrentVal = myHealth.health;
        FacingTarget();
        DeathCheck();
        // manaBar.CurrentVal = myMana.mana;
        GameControler.gameControler.enemyHealth = myHealth.health;
    }

    void FixedUpdate()
    {
        FollowPlayer();
        AttackPlayer();
        // manaBar.CurrentVal = myMana.mana;
        // manaBar.manaScript.MaxVal = myMana.maxMana;
    }

    void FollowPlayer()
    {
        if (!followPlayer && isDie)
            return;

        if (Mathf.Abs(transform.position.x - playerTransform.position.x) > attackDistance)
        {
            float moveDirection = playerTransform.position.x < transform.position.x ? -1 : 1;
            enemyRigidBody.velocity = new Vector2(moveDirection * movementSpeed, enemyRigidBody.velocity.y);
            enemyAnim.EnemyWalk(1); // Memanggil animasi walk saat karakter mulai berjalan
            // Debug.Log("Jalankan animasi");
        }
        else
        {
            enemyRigidBody.velocity = Vector2.zero;
            enemyAnim.EnemyWalk(0); // Memanggil animasi walk saat karakter berhenti berjalan
            followPlayer = false;
            attackPlayer = true;

        }
    }

    void AttackPlayer()
    {
        if (!attackPlayer || isDie)
            return;

        currentAttackTimer -= Time.deltaTime;
        if (currentAttackTimer <= 0)
        {
            Attack(Random.Range(0, 5));
            currentAttackTimer = deffaultAttackTimer;
        }

        if (Mathf.Abs(transform.position.x - playerTransform.position.x) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }

    void FacingTarget()
    {
        if (isDie)
            return;
        if (playerTransform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
    }

    IEnumerator Pukul(float time)
    {
        yield return new WaitForSeconds(time);
        enemyAnim.Pukul();
    }
    IEnumerator Senjata(float time)
    {
        yield return new WaitForSeconds(time);
        enemyAnim.Senjata();
    }
    // IEnumerator Bertahan(float time)
    // {
    //     yield return new WaitForSeconds(time);
    //     enemyAnim.Bertahan();
    // }

    void Attack(int i)
    {
        switch (i)
        {
            case 0:
                StartCoroutine(Pukul(0.1f));
                break;
            case 1:
                StartCoroutine(Senjata(0.3f));
                break;
                // case 2:
                //     StartCoroutine(Bertahan(0.3f));
                //     break;
        }
    }
    void DeathCheck()
    {
        if (isDie)
            return;
        if (myHealth.health <= 0)
        {
            isDie = true;
            enemyAnim.Die(isDie);
            GameControler.gameControler.isEnemyDead = isDie;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie)
            return;
        if (collision.tag == Tags.Pukul_Attack_Tag)
        {
            enemyAnim.Hurt();
            myHealth.health -= GetPlayer.pukulDamage;

        }
        if (collision.tag == Tags.Senjata_Attack_Tag)
        {
            enemyAnim.Hurt();
            myHealth.health -= GetPlayer.senjataDamage;
        }
    }
}
